using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class BillTypeCallManager
    {
        public UltimateResult<List<BillType>> GetBillTypes()
        {
            return BillTypeManager.Instance.GetBillTypes();
        }

        public UltimateResult<List<BillType>> DeleteBillType(BillType parameter)
        {
            return BillTypeManager.Instance.DeleteBillType(parameter);
        }

        public UltimateResult<List<BillType>> GetBillTypeByCompanyRefId(ReferansParameter parameter)
        {
            return BillTypeManager.Instance.GetBillTypeByCompanyRefId(parameter);
        }

        public UltimateResult<List<BillType>> AddBillType(BillType parameter)
        {
            return BillTypeManager.Instance.AddBillType(parameter);
        }

        public UltimateResult<List<BillType>> UpdateBillType(BillType parameter)
        {
            return BillTypeManager.Instance.UpdateBillType(parameter);
        }
    }
}
