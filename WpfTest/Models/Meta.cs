using System.Text.Json.Serialization;

namespace WpfTest.Models
{
    public class Meta
    {
        [JsonPropertyName("requested")]
        public int Requested { get; set; }
        [JsonPropertyName("returned")]
        public int Returned { get; set; }
        
    }
}
