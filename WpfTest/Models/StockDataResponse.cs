using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WpfTest.Models
{
    public class StockDataResponse
    {
        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }
        [JsonPropertyName("data")]
        public List<StockInfo> Data { get; set; }
    }
}
