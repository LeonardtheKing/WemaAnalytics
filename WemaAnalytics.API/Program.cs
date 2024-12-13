#region Application developed in September 2024 with .NET 8 by Chizaram Añumadu
using WemaAnalytics.Infrastructure.ActiveDirectory;
using WemaAnalytics.Infrastructure.JWT;
using WemaAnalytics.Infrastructure.Persistence.Seeding;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//Logger Setup
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

// Add services to the container
builder.Services.AddPresentationServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxResponseBufferSize = int.MaxValue;
});

builder.Host.UseSerilog();

builder.Services.Configure<ActiveDirectoryConfigOptions>(
    builder.Configuration.GetSection("ActiveDirectory"));

builder.Services.Configure<JwtConfigOptions>(
    builder.Configuration.GetSection("JwtSettings"));


WebApplication app = builder.Build();

// Request pipelines registry
app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint(builder.Configuration["AppSettings:SwaggerEndpoint"], string.Empty);
    s.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
});

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

// Call the SeedData method
await Seeder.SeedData(app.Services);

app.UseResponseCompression();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseHangfireDashboard(builder.Configuration["AppSettings:HangfireEndpoint"], new DashboardOptions
{
    Authorization = new[] { new HangfireDashboardAuthorizationFilter(builder.Configuration) }
});

app.Run();
#endregion
/*
 * The above code snippet is the entry point of the application. It is the Program.cs file in the WemaAnalytics.API project.
 * * The application is built using the .NET 8 framework and is developed by Henry Ozomgbachi in September 2024.
 * * The application uses Serilog for logging and Swagger for API documentation.
 * * It also includes middleware for handling global exceptions, authentication, authorization, and response compression.
 * * The application uses Hangfire for background job processing and has CORS policy configured for cross-origin requests.
 * * The application has separate services for presentation(API), application, infrastructure and domain layers.
 * * The architecture follows the CQRS pattern with MediatR for command and query handling.
 * * UnitOfWork and Repository patterns are used for data access.
 * */