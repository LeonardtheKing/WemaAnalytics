namespace WemaAnalytics.Infrastructure.Persistence.EntityConfigurations;

public class SOLEntityConfig : IEntityTypeConfiguration<SOLEntity>
{
    public void Configure(EntityTypeBuilder<SOLEntity> builder)
    {
        // Table Name
        builder.ToTable("SOLEntities");

     
        // Properties
        builder.Property(sol => sol.SOLCode)
               .HasMaxLength(3);

        // Relationships
        builder.HasMany(sol => sol.AccountOfficers)
               .WithOne(accountOfficer => accountOfficer.SOL)
               .HasForeignKey(accountOfficer => accountOfficer.SOLId)
               .OnDelete(DeleteBehavior.Restrict); //Does not delete AccountOfficers when SOL is deleted.

        builder
           .HasOne(s => s.Branch)
           .WithOne(b => b.SOL) // One-to-one relationship
           .HasForeignKey<SOLEntity>(s => s.BranchId) // Foreign Key in SOLEntity
           .OnDelete(DeleteBehavior.Cascade); // Optional: Define delete behavior
    }
}