using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WpfTest.Interfaces;
using WpfTest.Models;

namespace WpfTest.Services
{
    public class StockdataClient
    {
        private readonly HttpClient _client;
        private readonly IStringConverter _stringConverter;

        public StockdataClient(HttpClient client, IStringConverter stringConverter)
        {
            _client = client;
            _stringConverter = stringConverter;
        }


        public async Task<StockDataResponse> GetStockData(string symbols, string token)
        {
        
            var result = await _client.GetFromJsonAsync<StockDataResponse>($"/v1/data/quote?symbols={_stringConverter.ConvertToUrlString(symbols)}&api_token={token}");

            return result;
        }
    }
}
