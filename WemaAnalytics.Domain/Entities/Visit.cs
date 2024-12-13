namespace WemaAnalytics.Domain.Entities
{
    public class Visit : BaseEntity
    {
        public required string StaffEmail { get; set; }
        public required string CompanyName { get; set; }
        public required string Venue { get; set; }
        public VisitStatusEnums Status { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public required string Purpose { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }
}
