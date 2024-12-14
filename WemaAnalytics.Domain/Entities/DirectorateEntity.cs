namespace WemaAnalytics.Domain.Entities;

public class DirectorateEntity : BaseEntity
{
    public int DirectorateCode { get; set; }
    public string DirectorateName { get; set; } = string.Empty;


    // Navigation property back to ApplicationUser
    public List<ApplicationUser> ApplicationUser { get; set; } = default!;

    public ICollection<RegionEntity> Regions { get; set; } = new List<RegionEntity>(); // Navigation Property

    public DirectorateEntity()
    {

    }

   
   

   
    // Factory Method: Create a DirectorateEntity with default properties
    public static DirectorateEntity CreateDirectorate(int directorateCode, string directorateName)
    {
        return new DirectorateEntity
        {
            DirectorateCode = directorateCode,
            DirectorateName = directorateName
        };
    }
}
