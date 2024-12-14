namespace WemaAnalytics.Infrastructure.Persistence.EntityConfigurations;

public class BranchEntityConfig : BaseEntityConfig<BranchEntity>
{
    public override void Configure(EntityTypeBuilder<BranchEntity> builder)
    {
        base.Configure(builder);

        builder.ToTable("Branches");

        builder
            .Property(d => d.BranchCode)
            .IsRequired()
            .HasMaxLength(4);

        builder
            .Property(d => d.BranchName)
            .IsRequired()
            .HasMaxLength(100);

        // Configure Zone relationship
        builder
            .HasOne(b => b.Zone)
            .WithMany(z => z.Branches)
            .HasForeignKey(b => b.ZoneId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure SOL relationship
        builder
            .HasOne(b => b.SOL)
            .WithMany() // No navigation property from SOL to BranchEntity
            .HasForeignKey(b => b.SOLId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Restrict);

        builder
           .HasOne(b => b.SOL)
           .WithOne(s => s.Branch) // One-to-one relationship
           .HasForeignKey<BranchEntity>(b => b.SOLId) // Foreign Key in BranchEntity
           .OnDelete(DeleteBehavior.Cascade); // Optional: Define delete behavior
    }
}
