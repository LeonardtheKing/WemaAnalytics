namespace WemaAnalytics.Domain.Entities;

public class DirectorateEntity : BaseEntity
{
    public int DirectorateCode { get; set; }
    public string DirectorateName { get; set; } = string.Empty;

    // Foreign key for ApplicationUser
    public string ApplicationUserId { get; set; } = string.Empty;

    // Navigation property back to ApplicationUser
    public ApplicationUser ApplicationUser { get; set; } = default!;

    public ICollection<RegionEntity> Regions { get; set; } = new List<RegionEntity>(); // Navigation Property

    public DirectorateEntity()
    {

    }

    // Factory Method: Create a DirectorateEntity with ApplicationUser
    public static DirectorateEntity CreateWithUser(
        int directorateCode,
        string directorateName,
        string applicationUserId,
        ApplicationUser applicationUser)
    {
        return new DirectorateEntity
        {
            DirectorateCode = directorateCode,
            DirectorateName = directorateName,
            ApplicationUserId = applicationUserId,
            ApplicationUser = applicationUser
        };
    }

    // Factory Method: Create a DirectorateEntity with Regions
    public static DirectorateEntity CreateWithRegions(
        int directorateCode,
        string directorateName,
        string applicationUserId,
        ApplicationUser applicationUser,
        ICollection<RegionEntity> regions)
    {
        return new DirectorateEntity
        {
            DirectorateCode = directorateCode,
            DirectorateName = directorateName,
            ApplicationUserId = applicationUserId,
            ApplicationUser = applicationUser,
            Regions = regions
        };
    }

    // Factory Method: Create a DirectorateEntity with default properties
    public static DirectorateEntity CreateDefault(int directorateCode, string directorateName)
    {
        return new DirectorateEntity
        {
            DirectorateCode = directorateCode,
            DirectorateName = directorateName
        };
    }
}
