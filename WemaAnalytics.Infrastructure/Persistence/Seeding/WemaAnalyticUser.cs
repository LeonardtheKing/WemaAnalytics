using Microsoft.Data.SqlClient;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WemaAnalytics.Infrastructure.Persistence.Seeding;

public class WemaAnalyticUser
{
    [JsonConverter(typeof(CleanGuidConverter))] // Apply the custom converter
    public Guid Id { get; set; }
    public string StaffId { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string NormalizedEmail { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string NormalizedUserName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public bool EmailConfirmed { get; set; }
    public string SecurityStamp { get; set; } = string.Empty;

    private readonly string _connectionString;
    private readonly string _jsonFilePath;

    public WemaAnalyticUser()
    {
        _connectionString = "Server=WEMA-CTI-L16943\\SQLEXPRESS;Database=WemaAnalytics_DB;Integrated Security=True;Encrypt=False";
        _jsonFilePath = "C:\\Users\\Izuchukwu.Okorie\\Desktop\\New folder\\WemaAnalytics\\WemaAnalytics.API\\WemaAnalytics\\WemaAnalytics.Infrastructure\\Persistence\\Seeding\\WemaAnalyticUsers.json";
    }

    public WemaAnalyticUser(string connectionString, string jsonFilePath)
    {
        _connectionString = connectionString;
        _jsonFilePath = jsonFilePath;
    }

    public async Task<List<WemaAnalyticUser>> ReadJsonFileAsync()
    {
        string json = await File.ReadAllTextAsync("C:\\Users\\Izuchukwu.Okorie\\Desktop\\New folder\\WemaAnalytics\\WemaAnalytics.Infrastructure\\Persistence\\Seeding\\WemaAnalyticUsers.json").ConfigureAwait(false);
        var users = JsonSerializer.Deserialize<List<WemaAnalyticUser>>(json);
        return users ?? new List<WemaAnalyticUser>();
    }

    public async Task SeedDataIntoDatabaseAsync(List<WemaAnalyticUser> users)
    {
        using (var connection = CreateConnection())
        {
            await connection.OpenAsync().ConfigureAwait(false);

            foreach (var user in users)
            {
              
                    await InsertUserAsync(user, connection).ConfigureAwait(false);
                
            }
        }
    }


    private async Task InsertUserAsync(WemaAnalyticUser user, SqlConnection connection)
    {
        const string insertQuery = @"
            INSERT INTO WemaAnalyticUsers 
                (Id, StaffId, FirstName, LastName, Email, NormalizedEmail, UserName, NormalizedUserName, PhoneNumber, 
                PhoneNumberConfirmed, EmailConfirmed, SecurityStamp, AccessFailedCount, LockoutEnd, LockoutEnabled, 
                TwoFactorEnabled, ConcurrencyStamp)
            VALUES 
                (@Id, @StaffId, @FirstName, @LastName, @Email, @NormalizedEmail, @UserName, @NormalizedUserName, 
                @PhoneNumber, @PhoneNumberConfirmed, @EmailConfirmed, @SecurityStamp, @AccessFailedCount, @LockoutEnd, 
                @LockoutEnabled, @TwoFactorEnabled, @ConcurrencyStamp)";

        using (var command = new SqlCommand(insertQuery, connection))
        {
            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = user.Id;
            command.Parameters.Add("@StaffId", SqlDbType.NVarChar).Value = user.StaffId;
            command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = user.FirstName;
            command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = user.LastName;
            command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = user.Email;
            command.Parameters.Add("@NormalizedEmail", SqlDbType.NVarChar).Value = user.NormalizedEmail;
            command.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = user.UserName;
            command.Parameters.Add("@NormalizedUserName", SqlDbType.NVarChar).Value = user.NormalizedUserName;
            command.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = user.PhoneNumber;
            command.Parameters.Add("@PhoneNumberConfirmed", SqlDbType.Bit).Value = false;
            command.Parameters.Add("@EmailConfirmed", SqlDbType.Bit).Value = user.EmailConfirmed;
            command.Parameters.Add("@SecurityStamp", SqlDbType.NVarChar).Value = user.SecurityStamp;
            command.Parameters.Add("@AccessFailedCount", SqlDbType.Int).Value = 0;
            command.Parameters.Add("@LockoutEnd", SqlDbType.DateTime).Value = DBNull.Value;
            command.Parameters.Add("@LockoutEnabled", SqlDbType.Bit).Value = false;
            command.Parameters.Add("@TwoFactorEnabled", SqlDbType.Bit).Value = false;
            command.Parameters.Add("@ConcurrencyStamp", SqlDbType.NVarChar).Value = Guid.NewGuid().ToString();

            await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }
    }

    private SqlConnection CreateConnection()
    {
        return new SqlConnection("Server=WEMA-CTI-L16943\\SQLEXPRESS;Database=WemaAnalytics_DB;Integrated Security=True;Encrypt=False");
    }
}
