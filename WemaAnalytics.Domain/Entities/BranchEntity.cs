namespace WemaAnalytics.Domain.Entities
{
    public class BranchEntity : BaseEntity
    {
        public int BranchCode { get; set; }
        public string BranchName { get; set; } = string.Empty;

        public Guid ZoneId { get; set; }
        public ZoneEntity Zone { get; set; } = default!;

        public Guid? ClusterId { get; set; }
        public ClusterEntity? Cluster { get; set; }

        public Guid SOLId { get; set; }
        public SOLEntity SOL { get; set; } = default!;

        public ICollection<AccountOfficerEntity> AccountOfficers { get; set; } = new List<AccountOfficerEntity>();


        public BranchEntity()
        {

        }

    }
}
