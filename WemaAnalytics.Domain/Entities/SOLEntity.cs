namespace WemaAnalytics.Domain.Entities;

public class SOLEntity : BaseEntity
{
    public int SOLId { get; set; }
   public ICollection<AccountOfficerEntity> AccountOfficers { get; set; } = new List<AccountOfficerEntity>();
}
