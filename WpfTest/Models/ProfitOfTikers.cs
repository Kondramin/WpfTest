namespace WpfTest.Models
{
    public class ProfitOfTikers
    {
        public string CompanyName { get; set; }
        public decimal Profit => MaxCost - MinCost;
        public decimal MinCost { get; set; }
        public decimal MaxCost { get; set; }
    }
}
