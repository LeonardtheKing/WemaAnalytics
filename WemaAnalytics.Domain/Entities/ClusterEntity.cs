namespace WemaAnalytics.Domain.Entities;

public class ClusterEntity : BaseEntity
{
    public int ClusterCode { get; set; }
    public string ClusterName { get; set; } = string.Empty;
    public Guid RegionId { get; set; }
    public RegionEntity Region { get; set; } = default!; // Navigation Property
    public ICollection<AccountOfficerEntity> Branches { get; set; } = new List<AccountOfficerEntity>(); // Navigation Property


    public ClusterEntity()
    {

    }

}
