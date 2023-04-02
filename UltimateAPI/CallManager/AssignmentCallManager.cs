using System.Collections.Generic;
using System.Linq;
using UltimateAPI.Entities;
using UltimateAPI.Entities.Enums;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class AssignmentCallManager
    {
        private static readonly object Lock = new object();
        private static volatile AssignmentCallManager _instance;
        public static AssignmentCallManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new AssignmentCallManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<Assignment>> GetAssignments(Assignment parameter)
        {
            return AssignmentManager.Instance.GetAssignments(parameter);
        }

        public UltimateResult<List<Assignment>> DeleteAssignment(Assignment parameter)
        {
            return AssignmentManager.Instance.DeleteAssignment(parameter);
        }

        public UltimateResult<List<Assignment>> AddAssignment(Assignment parameter)
        {
            bool isHaveItem = true;
            if (parameter.ItemType == ItemType.Accessory)
            {
                AccessoryCallManager accessoryModelCall = new AccessoryCallManager();
                isHaveItem = accessoryModelCall.GetAccessory(new Accessory() { Id = parameter.ItemId }).Data[0].Piece >= parameter.Piece;
            }
            //else if (parameter.ItemType == ItemType.Bill)
            //{
            //    BillCallManager billCallManager = new BillCallManager();
            //    isHaveItem = billCallManager.GetBills().Data.Find(x => x.Id == parameter.ItemId);
            //}
            else if (parameter.ItemType == ItemType.Companent)
            {
                ComponentCallManager componentCallManager = new ComponentCallManager();
                isHaveItem = componentCallManager.GetComponents().Data.Find(x => x.Id == parameter.ItemId).Piece >= parameter.Piece;
            }
            else if (parameter.ItemType == ItemType.Fixture)
            {
                isHaveItem = FixtureCallManager.Instance.GetFixture(new Fixture() { Id = parameter.ItemId }).Data[0].StatuNo == (int)ItemStatu.Ready;
            }
            else if (parameter.ItemType == ItemType.Licence)
            {
                LicenseCallManager licenseCallManager = new LicenseCallManager();
                isHaveItem = licenseCallManager.GetLicenses().Data.Find(x => x.Id == parameter.ItemId).Piece >= parameter.Piece;
            }
            else if (parameter.ItemType == ItemType.Toner)
            {
                TonerCallManager tonerCallManager = new TonerCallManager();
                isHaveItem = tonerCallManager.GetToners().Data.Find(x => x.Id == parameter.ItemId).Piece >= parameter.Piece;
            }

            if (!isHaveItem)
            {
                UltimateResult<List<Assignment>> result = new UltimateResult<List<Assignment>>();
                result.IsSuccess = false;
                result.Message = "Atanan miktarda ürün bulunamadı.";
                return result;
            }






            return AssignmentManager.Instance.AddAssignment(parameter);
        }

        public UltimateResult<List<Assignment>> UpdateAssignment(Assignment parameter)
        {
            return AssignmentManager.Instance.UpdateAssignment(parameter);
        }

        public UltimateResult<List<Assignment>> GetAssignmentUser(Assignment parameter)
        {
            return AssignmentManager.Instance.GetAssignmentUser(parameter);
        }
    }
}
