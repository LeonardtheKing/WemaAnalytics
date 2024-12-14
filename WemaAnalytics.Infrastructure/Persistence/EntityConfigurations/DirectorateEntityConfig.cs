namespace WemaAnalytics.Infrastructure.Persistence.EntityConfigurations;

public class DirectorateEntityConfig : BaseEntityConfig<DirectorateEntity>
{
    public override void Configure(EntityTypeBuilder<DirectorateEntity> builder)
    {
        base.Configure(builder);

        builder.ToTable("Directorates");

        builder
            .Property(d => d.DirectorateCode)
            .IsRequired()
            .HasMaxLength(4);

        builder
            .Property(d => d.DirectorateName)
            .IsRequired()
            .HasMaxLength(100);



        // One-to-many relationship with RegionEntity
        builder
            .HasMany(d => d.Regions)
            .WithOne(r => r.Directorate)
            .HasForeignKey(r => r.DirectorateId) // Foreign key in RegionEntity
            .OnDelete(DeleteBehavior.Restrict); // Optional: Restrict delete

    }
}
