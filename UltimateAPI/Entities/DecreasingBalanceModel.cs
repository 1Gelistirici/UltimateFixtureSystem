
namespace UltimateAPI.Entities
{
    public class DecreasingBalanceModel
    {
        public decimal ValueReceived { get; set; }
        public decimal Scrapvalue { get; set; }
        public decimal Life { get; set; }
        public decimal MonthlyDepreciationRate
        {
            get
            {
                return 1m / (12m * Life); // Aylık amortisman oranı hesaplama
            }
        }
        public int NumberOfLastMonth { get; set; }
    }
}
