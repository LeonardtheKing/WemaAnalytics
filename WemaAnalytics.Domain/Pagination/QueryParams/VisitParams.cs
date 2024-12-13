namespace WemaAnalytics.Domain.Pagination.QueryParams
{
    public class VisitParams : BaseParam
    {
        public string? StaffEmail { get; set; }
        public VisitStatusEnums? VisitStatus { get; set; }
    }
}
