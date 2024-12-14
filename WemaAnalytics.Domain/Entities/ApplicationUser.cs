namespace WemaAnalytics.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public required string StaffId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    // Navigation properties for relationships
    public Guid? DirectorateId { get; set; }
    public DirectorateEntity? Directorate { get; set; }

    public Guid? RegionId { get; set; }
    public RegionEntity? Region { get; set; }

    public Guid? ZoneId { get; set; }
    public ZoneEntity? Zone { get; set; }

    public Guid? BranchId { get; set; }
    public BranchEntity? Branch { get; set; }

    public Guid? ClusterId { get; set; }
    public ClusterEntity? Cluster { get; set; }

    public Guid? SOLId { get; set; }
    public SOLEntity? SOL { get; set; }



}
