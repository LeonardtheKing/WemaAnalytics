namespace WemaAnalytics.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public required string StaffId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    //public string? RefreshToken { get; set; }
    //public DateTime RefreshTokenExpiryTime { get; set; }

    // Navigation property for the directorate
    public DirectorateEntity? Directorate { get; set; }


  
}
