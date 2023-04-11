
namespace UltimateAPI.Entities
{
    public class FixedAnnualAmountModel
    {
        public double Cost { get; set; }
        public double RecoveryValue { get; set; }
        public int EconomicSpine { get; set; }
        public double FixedAnnualAmount
        {
            get
            {
                return (Cost - RecoveryValue) / EconomicSpine;
            }
        }


    }
}
