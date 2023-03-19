using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class BillCallManager
    {
        public UltimateResult<List<Bill>> GetBills()
        {
            return BillManager.Instance.GetBills();
        }

        public UltimateResult<List<Bill>> DeleteBill(Bill parameter)
        {
            UltimateResult<List<Bill>> result = new UltimateResult<List<Bill>>();
            List<Bill> bills = BillManager.Instance.GetBills().Data;

            return BillManager.Instance.DeleteBill(parameter);
        }

        public UltimateResult<List<Bill>> AddBill(Bill parameter)
        {
            return BillManager.Instance.AddBill(parameter);
        }

        public UltimateResult<List<Bill>> UpdateBill(Bill parameter)
        {
            return BillManager.Instance.UpdateBill(parameter);
        }
    }
}
