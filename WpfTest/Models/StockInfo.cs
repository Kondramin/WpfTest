using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WpfTest.Models
{
    public class StockInfo
    {
        [JsonPropertyName("ticker")]
        public string Ticker { get; set; }


        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonPropertyName("exchange_short")]
        public string ExchangeShort { get; set; }


        [JsonPropertyName("exchange_long")]
        public string ExchangeLong { get; set; }


        [JsonPropertyName("mic_code")]
        public string MicCode { get; set; }


        [JsonPropertyName("currency")]
        public string Currency { get; set; }


        [JsonPropertyName("price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }


        [JsonPropertyName("day_high")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal DayHigh { get; set; }


        [JsonPropertyName("day_low")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal DayLow { get; set; }


        [JsonPropertyName("day_open")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal DayOpen { get; set; }


        [JsonPropertyName("52_week_high")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal YearHigh { get; set; }


        [JsonPropertyName("52_week_low")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal YearLow { get; set; }


        [JsonPropertyName("market_cap")]
        public long MarketCap { get; set; }


        [JsonPropertyName("previous_close_price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PreviousClosePrice { get; set; }


        [JsonPropertyName("previous_close_price_time")]
        public DateTime PreviousClosePriceTime { get; set; }


        [JsonPropertyName("day_change")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal DayChange { get; set; }


        [JsonPropertyName("volume")]
        public int TotalVolume { get; set; }


        [JsonPropertyName("is_extended_hours_price")]
        public bool IsExtendedHoursPrice { get; set; }


        [JsonPropertyName("last_trade_time")]
        public DateTime LastTradeTime { get; set; }

    }
}
