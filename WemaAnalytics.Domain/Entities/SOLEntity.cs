namespace WemaAnalytics.Domain.Entities;

public class SOLEntity : BaseEntity
{
    public int SOLCode { get; set; }

    // One-to-one relationship with BranchEntity
    public Guid BranchId { get; set; } // Foreign Key
    public BranchEntity Branch { get; set; } = default!; // Navigation Property
    public ICollection<AccountOfficerEntity> AccountOfficers { get; set; } = new List<AccountOfficerEntity>();

    public SOLEntity()
    {

    }
}
