namespace WemaAnalytics.Infrastructure.Persistence.EntityConfigurations
{
    public class VisitConfig : BaseEntityConfig<Visit>
    {
        public override void Configure(EntityTypeBuilder<Visit> builder)
        {
            base.Configure(builder);

            builder.ToTable("Visits");
            builder.HasIndex(v => v.StaffEmail);

            builder
                .Property(v => v.StaffEmail)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(v => v.Status)
                .IsRequired()
                .HasConversion<EnumToStringConverter<VisitStatusEnums>>()
                .HasMaxLength(50);

            builder
                .Property(v => v.CompanyName)
                .IsRequired()
                .HasMaxLength(256);

            builder
                .Property(v => v.Venue)
                .IsRequired()
                .HasMaxLength(256);

            builder
                .Property(v => v.Purpose)
                .IsRequired()
                .HasMaxLength(2000);

            builder
                .Property(v => v.Date)
                .IsRequired();

            builder
                .Property(v => v.Time)
                .IsRequired();
        }
    }
}
