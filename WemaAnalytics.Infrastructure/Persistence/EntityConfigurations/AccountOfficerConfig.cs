namespace WemaAnalytics.Infrastructure.Persistence.EntityConfigurations;

public class AccountOfficerConfig : BaseEntityConfig<AccountOfficerEntity>
{
    public override void Configure(EntityTypeBuilder<AccountOfficerEntity> builder)
    {
        base.Configure(builder);

        builder.ToTable("AccountOfficers");

        builder
            .Property(d => d.AccountOfficerCode)
            .IsRequired()
            .HasMaxLength(4);

        builder
            .Property(d => d.AccountOfficerName)
            .IsRequired()
            .HasMaxLength(100);

        builder
           .HasOne(ao => ao.Branch)
           .WithMany(b => b.AccountOfficers)
           .HasForeignKey(ao => ao.BranchId) // Specifies BranchId as the foreign key
           .OnDelete(DeleteBehavior.Cascade); // Optional: Cascade delete or restrict


    }
}





