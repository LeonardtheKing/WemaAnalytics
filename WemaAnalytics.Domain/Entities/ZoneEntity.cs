namespace WemaAnalytics.Domain.Entities;

public class ZoneEntity : BaseEntity
{
    public int ZoneCode { get; set; }
    public string ZoneName { get; set; } = string.Empty;

    // Foreign key property for RegionEntity
    public Guid RegionId { get; set; }

    // Navigation property to RegionEntity
    public RegionEntity Region { get; set; } = default!;

    // Navigation property for BranchEntity
    public ICollection<BranchEntity> Branches { get; set; } = new List<BranchEntity>();

    public ZoneEntity()
    {

    }

    // Factory Method: Create a ZoneEntity with Region
    public static ZoneEntity CreateWithRegion(
        int zoneCode,
        string zoneName,
        Guid regionId,
        RegionEntity region)
    {
        return new ZoneEntity
        {
            ZoneCode = zoneCode,
            ZoneName = zoneName,
            RegionId = regionId,
            Region = region
        };
    }

    // Factory Method: Create a ZoneEntity with Branches
    public static ZoneEntity CreateWithBranches(
        int zoneCode,
        string zoneName,
        Guid regionId,
        RegionEntity region,
        ICollection<BranchEntity> branches)
    {
        return new ZoneEntity
        {
            ZoneCode = zoneCode,
            ZoneName = zoneName,
            RegionId = regionId,
            Region = region,
            Branches = branches
        };
    }

    // Factory Method: Create a ZoneEntity with default properties
    public static ZoneEntity CreateDefault(int zoneCode, string zoneName)
    {
        return new ZoneEntity
        {
            ZoneCode = zoneCode,
            ZoneName = zoneName
        };
    }
}
