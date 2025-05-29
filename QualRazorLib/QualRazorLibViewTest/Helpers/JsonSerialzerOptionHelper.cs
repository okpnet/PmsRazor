using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace QualRazorLibViewTest.Helpers
{
    public static class JsonSerialzerOptionHelper
    {
        public static JsonSerializerOptions CreateOption()
        {
            return new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IgnoreReadOnlyFields = true,
                WriteIndented = true
            };
        }
    }
}
