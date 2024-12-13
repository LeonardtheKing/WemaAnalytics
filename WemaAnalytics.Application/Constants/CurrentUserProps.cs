namespace WemaAnalytics.Application.Constants
{
    public abstract record CurrentUserProps
    {
        [BindNever]
        [System.Text.Json.Serialization.JsonIgnore]
        public string? CurrentUserEmail { get; set; }

        [BindNever]
        [System.Text.Json.Serialization.JsonIgnore]
        public string? CurrentUserId { get; set; }
    }
}
