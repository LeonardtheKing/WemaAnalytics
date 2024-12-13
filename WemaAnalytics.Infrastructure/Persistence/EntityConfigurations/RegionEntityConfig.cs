namespace WemaAnalytics.Infrastructure.Persistence.EntityConfigurations;

public class RegionEntityConfig : BaseEntityConfig<RegionEntity>
{
    public override void Configure(EntityTypeBuilder<RegionEntity> builder)
    {
        base.Configure(builder);

        builder.ToTable("Regions");

        builder
            .Property(d => d.RegionCode)
            .IsRequired()
            .HasMaxLength(4);

        builder
            .Property(d => d.RegionName)
            .IsRequired()
            .HasMaxLength(100);

        // Foreign key configuration
        builder
            .HasOne(r => r.Directorate)
            .WithMany(d => d.Regions)
            .HasForeignKey(r => r.DirectorateId)
            .OnDelete(DeleteBehavior.Cascade); // Optional: Restrict delete
    }
}

