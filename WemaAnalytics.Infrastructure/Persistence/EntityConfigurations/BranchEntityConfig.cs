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


        builder
            .HasOne(b => b.Zone)
            .WithMany(z => z.Branches)
            .HasForeignKey(b => b.ZoneId) // Specifies ZoneId as the foreign key
            .OnDelete(DeleteBehavior.Cascade); // Optional: Cascade delete or restrict

    }
}
