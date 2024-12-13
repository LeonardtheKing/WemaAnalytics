namespace WemaAnalytics.Infrastructure.Persistence.EntityConfigurations;

public class SOLEntityConfig : IEntityTypeConfiguration<SOLEntity>
{
    public void Configure(EntityTypeBuilder<SOLEntity> builder)
    {
        // Table Name
        builder.ToTable("SOLEntities");

     
        // Properties
        builder.Property(sol => sol.SOLId)
               .HasMaxLength(3);

        // Relationships
        builder.HasMany(sol => sol.AccountOfficers)
               .WithOne(accountOfficer => accountOfficer.SOL)
               .HasForeignKey(accountOfficer => accountOfficer.SOLId)
               .OnDelete(DeleteBehavior.Cascade); // Deletes AccountOfficers when SOL is deleted.

        // Additional Configuration (if any)
    }
}