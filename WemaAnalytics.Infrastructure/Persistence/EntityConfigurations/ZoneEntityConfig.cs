namespace WemaAnalytics.Infrastructure.Persistence.EntityConfigurations;

public class ZoneEntityConfig : BaseEntityConfig<ZoneEntity>
{
    public override void Configure(EntityTypeBuilder<ZoneEntity> builder)
    {
        base.Configure(builder);

        builder.ToTable("Zones");

        builder
            .Property(d => d.ZoneCode)
            .IsRequired()
            .HasMaxLength(4);

        builder
            .Property(d => d.ZoneName)
            .IsRequired()
            .HasMaxLength(100);

        // Foreign key configuration
       
    }
}
