namespace WemaAnalytics.Domain.Entities;

public class AccountOfficerEntity:BaseEntity
{
    public int AccountOfficerCode { get; set; }
    public string AccountOfficerName { get; set; } = string.Empty;

    // Foreign key property for BranchEntity
    public Guid BranchId { get; set; }

    // Navigation property to BranchEntity
    public BranchEntity Branch { get; set; } = default!;

    // Foreign key property for SOLEntity
    public Guid SOLId { get; set; }

    // Navigation property to SOLEntity
    public SOLEntity SOL { get; set; } = default!;
}
