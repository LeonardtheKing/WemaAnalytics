using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace WemaAnalytics.Infrastructure.Persistence.Seeding
{
    public class CleanGuidConverter : JsonConverter<Guid>
    {
        private static HashSet<Guid> _generatedGuids = new HashSet<Guid>();

        // Method to clean the GUID string by replacing invalid characters with valid ones
        private Guid CleanGuid(string guidString)
        {
            // Remove any non-hexadecimal characters (anything not 0-9 or a-f)
            string cleanedGuidString = Regex.Replace(guidString, @"[^0-9a-fA-F]", "a");

            // Ensure the cleaned GUID string has exactly 32 characters
            cleanedGuidString = cleanedGuidString.Length > 32 ? cleanedGuidString.Substring(0, 32) : cleanedGuidString.PadRight(32, 'a');

            // Format the cleaned GUID string to match the format "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
            cleanedGuidString = cleanedGuidString.Substring(0, 8) + "-" + cleanedGuidString.Substring(8, 4) + "-" + cleanedGuidString.Substring(12, 4) + "-" + cleanedGuidString.Substring(16, 4) + "-" + cleanedGuidString.Substring(20, 12);

            // Parse the cleaned and formatted string into a Guid
            return Guid.Parse(cleanedGuidString);
        }

        public override Guid Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Read the GUID as a string and clean it
            string guidString = reader.GetString();
            Guid cleanedGuid = CleanGuid(guidString);

            // Check if the Guid already exists
            if (_generatedGuids.Contains(cleanedGuid))
            {
                // If it exists, generate a new Guid
                cleanedGuid = Guid.NewGuid();
                while (_generatedGuids.Contains(cleanedGuid))
                {
                    cleanedGuid = Guid.NewGuid();
                }
            }

            // Add the new Guid to the set
            _generatedGuids.Add(cleanedGuid);

            return cleanedGuid;
        }

        public override void Write(Utf8JsonWriter writer, Guid value, JsonSerializerOptions options)
        {
            // Write the GUID as a string
            writer.WriteStringValue(value.ToString());
        }
    }
}