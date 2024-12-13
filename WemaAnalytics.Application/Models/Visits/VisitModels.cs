namespace WemaAnalytics.Application.Models.Visits
{
    public record VisitModel : BaseModel
    {
        public required string CompanyName { get; set; }
        public required string Venue { get; set; }
        public required string Purpose { get; set; }
        public VisitStatusEnums Status { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }
}
