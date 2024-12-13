namespace WemaAnalytics.Domain.Entities;

public class RegionEntity : BaseEntity
{
    public int RegionCode { get; set; }
    public string RegionName { get; set; } = string.Empty;

    // Foreign key property for DirectorateEntity
    public Guid DirectorateId { get; set; }

    // Navigation property to DirectorateEntity
    public DirectorateEntity Directorate { get; set; } = default!;

    // Navigation properties for clusters and zones
    public ICollection<ClusterEntity> Clusters { get; set; } = new List<ClusterEntity>();
    public ICollection<ZoneEntity> Zones { get; set; } = new List<ZoneEntity>();

    public RegionEntity()
    {

    }
    // Factory Method: Create a RegionEntity with a Directorate
    public static RegionEntity CreateWithDirectorate(
        int regionCode,
        string regionName,
        Guid directorateId,
        DirectorateEntity directorate)
    {
        return new RegionEntity
        {
            RegionCode = regionCode,
            RegionName = regionName,
            DirectorateId = directorateId,
            Directorate = directorate
        };
    }

    // Factory Method: Create a RegionEntity with Clusters
    public static RegionEntity CreateWithClusters(
        int regionCode,
        string regionName,
        Guid directorateId,
        DirectorateEntity directorate,
        ICollection<ClusterEntity> clusters)
    {
        return new RegionEntity
        {
            RegionCode = regionCode,
            RegionName = regionName,
            DirectorateId = directorateId,
            Directorate = directorate,
            Clusters = clusters
        };
    }

    // Factory Method: Create a RegionEntity with Zones
    public static RegionEntity CreateWithZones(
        int regionCode,
        string regionName,
        Guid directorateId,
        DirectorateEntity directorate,
        ICollection<ZoneEntity> zones)
    {
        return new RegionEntity
        {
            RegionCode = regionCode,
            RegionName = regionName,
            DirectorateId = directorateId,
            Directorate = directorate,
            Zones = zones
        };
    }

    // Factory Method: Create a RegionEntity with Clusters and Zones
    public static RegionEntity CreateWithClustersAndZones(
        int regionCode,
        string regionName,
        Guid directorateId,
        DirectorateEntity directorate,
        ICollection<ClusterEntity> clusters,
        ICollection<ZoneEntity> zones)
    {
        return new RegionEntity
        {
            RegionCode = regionCode,
            RegionName = regionName,
            DirectorateId = directorateId,
            Directorate = directorate,
            Clusters = clusters,
            Zones = zones
        };
    }

    // Factory Method: Create a RegionEntity with default properties
    public static RegionEntity CreateDefault(int regionCode, string regionName)
    {
        return new RegionEntity
        {
            RegionCode = regionCode,
            RegionName = regionName
        };
    }
}
