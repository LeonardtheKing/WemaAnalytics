namespace WemaAnalytics.Infrastructure.ActiveDirectory;


    public class ActiveDirectoryConfigOptions
    {
        
    public string Domain { get; init; } = string.Empty;
    public string LDapServerIP { get; init; } = string.Empty;
    public int LDapServerPort { get; init; }

     }


