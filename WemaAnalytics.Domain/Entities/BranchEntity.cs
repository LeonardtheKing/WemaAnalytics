namespace WemaAnalytics.Domain.Entities
{
    public class BranchEntity : BaseEntity
    {
        public int BranchCode { get; set; }
        public string BranchName { get; set; } = string.Empty;

        // Foreign key property for ZoneEntity
        public Guid ZoneId { get; set; }

        // Navigation property to ZoneEntity
        public ZoneEntity Zone { get; set; } = default!;

        // Foreign key property for ClusterEntity
        public Guid? ClusterId { get; set; }

        // Navigation property to ClusterEntity
        public ClusterEntity? Cluster { get; set; }
        public ICollection<AccountOfficerEntity> AccountOfficers { get; set; } = new List<AccountOfficerEntity>(); // Navigation Property


        public BranchEntity()
        {

        }

        // Factory Method to Create a BranchEntity with required properties
        public static BranchEntity CreateWithZone(int branchCode, string branchName, Guid zoneId, ZoneEntity zone)
        {
            return new BranchEntity
            {
                BranchCode = branchCode,
                BranchName = branchName,
                ZoneId = zoneId,
                Zone = zone
            };
        }

        // Factory Method to Create a BranchEntity with optional ClusterEntity
        public static BranchEntity CreateWithCluster(
            int branchCode,
            string branchName,
            Guid zoneId,
            ZoneEntity zone,
            Guid? clusterId,
            ClusterEntity? cluster)
        {
            return new BranchEntity
            {
                BranchCode = branchCode,
                BranchName = branchName,
                ZoneId = zoneId,
                Zone = zone,
                ClusterId = clusterId,
                Cluster = cluster
            };
        }

        // Factory Method to Create a BranchEntity with Account Officers
        public static BranchEntity CreateWithAccountOfficers(
            int branchCode,
            string branchName,
            Guid zoneId,
            ZoneEntity zone,
            ICollection<AccountOfficerEntity> accountOfficers)
        {
            return new BranchEntity
            {
                BranchCode = branchCode,
                BranchName = branchName,
                ZoneId = zoneId,
                Zone = zone,
                AccountOfficers = accountOfficers
            };
        }
    }
}
