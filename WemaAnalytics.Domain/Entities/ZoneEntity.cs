namespace WemaAnalytics.Domain.Entities;

public class ZoneEntity : BaseEntity
{
    public int ZoneCode { get; set; }
    public string ZoneName { get; set; } = string.Empty;

    public Guid RegionId { get; set; }
    public RegionEntity Region { get; set; } = default!;

    public ICollection<BranchEntity> Branches { get; set; } = new List<BranchEntity>();
    public ICollection<AccountOfficerEntity> AccountOfficers { get; set; } = new List<AccountOfficerEntity>();

    public ZoneEntity()
    {

    }

    
}
