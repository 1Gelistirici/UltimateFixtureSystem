using System.Collections.Generic;
using System.Linq;
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
            Bill bill = BillManager.Instance.GetBills().Data.Where(x => x.Id == parameter.Id).ToList()[0];
            bool isHaveItem = bill.Items.Count > 0;

            if (isHaveItem)
            {
                UltimateResult<List<Bill>> result = new UltimateResult<List<Bill>>();
                result.IsSuccess = false;
                result.Message = "Fatura silinemedi. Faturaya ait ürünler bulunmaktadır.";
                return result;
            }

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
