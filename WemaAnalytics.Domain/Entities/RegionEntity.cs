namespace WemaAnalytics.Domain.Entities;

public class RegionEntity : BaseEntity
{
    public int RegionCode { get; set; }
    public string RegionName { get; set; } = string.Empty;

    public Guid DirectorateId { get; set; }
    public DirectorateEntity Directorate { get; set; } = default!;

    public ICollection<ClusterEntity> Clusters { get; set; } = new List<ClusterEntity>();
    public ICollection<ZoneEntity> Zones { get; set; } = new List<ZoneEntity>();
    public ICollection<BranchEntity> Branches { get; set; } = new List<BranchEntity>();

    public RegionEntity()
    {

    }
    

    // Factory Method: Create a RegionEntity with default properties
    public static RegionEntity CreateRegion(int regionCode, string regionName)
    {
        return new RegionEntity
        {
            RegionCode = regionCode,
            RegionName = regionName
        };
    }
}
