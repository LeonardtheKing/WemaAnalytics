namespace WemaAnalytics.Domain.Enums
{
    public enum VisitStatusEnums
    {
        [Description("A pending visit is a visit that has not yet been completed.")]
        Pending = 1,

        [Description("A completed visit is a visit that has been completed.")]
        Completed = 2,
    }
}
