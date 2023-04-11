
namespace UltimateAPI.Entities
{
    public class DepreciationByProductionAmountModel
    {
        public decimal AssetCost { get; set; }
        public decimal SalvageValue { get; set; }
        public decimal ProductionCapacity { get; set; }
        public decimal ProductionAmount { get; set; }
        public decimal LifeSpanInYears { get; set; }
    }
}
