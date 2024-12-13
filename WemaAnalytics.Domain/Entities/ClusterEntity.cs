namespace WemaAnalytics.Domain.Entities;

public class ClusterEntity : BaseEntity
{
    public int ClusterCode { get; set; }
    public string ClusterName { get; set; } = string.Empty;
    public RegionEntity Region { get; set; } = default!; // Navigation Property
    public ICollection<AccountOfficerEntity> Branches { get; set; } = new List<AccountOfficerEntity>(); // Navigation Property


    public ClusterEntity()
    {

    }

    // Factory Method: Create a ClusterEntity with Region
    public static ClusterEntity CreateWithRegion(int clusterCode, string clusterName, RegionEntity region)
    {
        return new ClusterEntity
        {
            ClusterCode = clusterCode,
            ClusterName = clusterName,
            Region = region
        };
    }

    // Factory Method: Create a ClusterEntity with Branches
    public static ClusterEntity CreateWithBranches(
        int clusterCode,
        string clusterName,
        RegionEntity region,
        ICollection<AccountOfficerEntity> branches)
    {
        return new ClusterEntity
        {
            ClusterCode = clusterCode,
            ClusterName = clusterName,
            Region = region,
            Branches = branches
        };
    }

    // Factory Method: Create a ClusterEntity with default properties
    public static ClusterEntity CreateDefault(int clusterCode, string clusterName)
    {
        return new ClusterEntity
        {
            ClusterCode = clusterCode,
            ClusterName = clusterName
        };
    }
}
