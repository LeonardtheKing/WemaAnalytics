using WemaAnalytics.Application.Login.Command;
using WemaAnalytics.Domain.Contract;
using WemaAnalytics.Infrastructure.ActiveDirectory;

namespace WemaAnalytics.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            #region Microsoft Identity and Authentication
            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromMinutes(5);
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.SignIn.RequireConfirmedEmail = true;
            })
            .AddEntityFrameworkStores<SqlDbContext>()
            .AddDefaultTokenProviders();

            TokenValidationParameters tokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidAudience = config["JwtSettings:ValidAudience"],
                ValidIssuer = config["JwtSettings:ValidIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:SecretKey"] ?? "super-secret"))
            };

            services.AddSingleton(tokenValidationParameters);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = tokenValidationParameters;
            });
            services.AddScoped<IJwtService, JwtService>();
            #endregion

            #region Miscellaneous Injections
            // Add HttpContextAccessor
            services.AddHttpContextAccessor();
            services.AddScoped<IAccessorService, AccessorService>();

            // Add AutoMapper
           // services.AddAutoMapper(typeof(VisitMappings).Assembly);

            // Add MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(LoginCommandHandler).Assembly));

            services.AddScoped<IActiveDirectoryService,ActiveDirectoryService>();

            // Add FluentValidation
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
           // services.AddValidatorsFromAssemblyContaining<CreateVisitCommandValidator>();

            // Others
            services.AddOptions<AppSettings>().Bind(config.GetSection("AppSettings"));
            services.AddSingleton<UtilityHelper>();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            #endregion

            #region Mailing HttpClient Factory
            services.AddHttpClient("Mail")
            .ConfigureHttpClient(client =>
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            })
            .ConfigurePrimaryHttpMessageHandler(() =>
            {
                return new HttpClientHandler
                {
                    UseDefaultCredentials = true,
                    SslProtocols = System.Security.Authentication.SslProtocols.Tls12,
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };
            });
            services.AddScoped<IMailService, MailService>();
            #endregion

            #region Hangfire Setup
            services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(config.GetConnectionString("DefaultConnection"), new SqlServerStorageOptions
            {
                CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                QueuePollInterval = TimeSpan.Zero,
                UseRecommendedIsolationLevel = true,
                DisableGlobalLocks = true
            }));
            services.AddHangfireServer();
            services.AddSingleton<IQueueService, QueueService>();
            services.AddSingleton<AuthJobs>();
            #endregion

            return services;
        }
    }
}
