namespace WemaAnalytics.Infrastructure.Data.DbContexts
{
    public class SqlDbContext(DbContextOptions<SqlDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Visit> Visits { get; set; }
        public DbSet<ZoneEntity> Zones { get; set; }
        public DbSet<BranchEntity> Branches { get; set; }
        public DbSet<DirectorateEntity> Directorates { get; set; }
        public DbSet<RegionEntity> Regions { get; set; }
        public DbSet<SOLEntity> SOLEntities { get; set; }
        public DbSet<AccountOfficerEntity> AccountOfficers { get; set; }
        public DbSet<ClusterEntity> Clusters { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           // modelBuilder.HasDefaultSchema("WemaAnalytics");

            modelBuilder.ApplyConfiguration(new ApplicationUserConfig());
            modelBuilder.ApplyConfiguration(new ZoneEntityConfig());
            modelBuilder.ApplyConfiguration(new BranchEntityConfig());
            modelBuilder.ApplyConfiguration(new DirectorateEntityConfig());
            modelBuilder.ApplyConfiguration(new RegionEntityConfig());
            modelBuilder.ApplyConfiguration(new SOLEntityConfig());
            modelBuilder.ApplyConfiguration(new AccountOfficerConfig());

            modelBuilder.ApplyConfiguration(new VisitConfig());
        }
    }
}
