using Microsoft.EntityFrameworkCore;

namespace WemaAnalytics.Infrastructure.Persistence.EntityConfigurations;

public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("WemaAnalyticUsers");

        builder.Property(x => x.FirstName).HasMaxLength(100);
        builder.Property(x => x.LastName).HasMaxLength(100);
        //builder.Property(x => x.RefreshToken).HasMaxLength(256);
        builder.Property(x => x.PhoneNumber).HasMaxLength(50);

        builder
          .Property(d => d.StaffId)
          .IsRequired()
          .HasMaxLength(9);
    }
}
