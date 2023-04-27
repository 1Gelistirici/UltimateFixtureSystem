using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Entities.Enums;
using UltimateAPI.Manager;
using UltimateDemerbas.Models;

namespace UltimateAPI.CallManager
{
    public class ItemHistoryCallManager
    {
        public static ItemHistoryManager itemHistory;
        private static readonly object Lock = new object();
        private static volatile ItemHistoryCallManager _instance;
        public static ItemHistoryCallManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ItemHistoryCallManager();
                            itemHistory = new ItemHistoryManager();
                        }
                    }
                }
                return _instance;
            }
        }


        public UltimateResult<List<ItemHistory>> GetItemHistoryByCompany(ReferansParameter parameter)
        {
            List<User> users = UserManager.Instance.GetUserCompany(new User() { CompanyId = parameter.RefId }).Data;
            List<Accessory> accessories = AccessoryManager.Instance.GetAccessories().Data;
            List<Bill> bills = BillManager.Instance.GetBills().Data;
            List<Component> components = ComponentManager.Instance.GetComponents().Data;
            List<License> licenses = LicenseManager.Instance.GetLicenses().Data;
            List<Toner> toners = TonerManager.Instance.GetToners().Data;
            List<Fixture> fixtures = FixtureManager.Instance.GetFixtures().Data;
            UltimateResult<List<ItemHistory>> result = itemHistory.GetItemHistoryByCompany(parameter);
            List<TextValue> itemTypeList = EnumCallManager.Instance.GetItemTypeTypes().Data;
            List<TextValue> ProcessTypeList = EnumCallManager.Instance.GetProcessTypes().Data;


            foreach (var item in result.Data)
            {
                item.ProcessTypeTextValue = ProcessTypeList.Find(x => x.Value == (int)item.ProcessType);
                item.ItemTypeTextValue = itemTypeList.Find(x => x.Value == (int)item.ItemType);
                item.TransactionUser = users.Find(x => x.Id == item.TransactionUserRefId);
                item.CommittedUser = users.Find(x => x.Id == item.CommittedUserRefId);

                if (item.ItemType == ItemType.Accessory)
                {
                    item.Accessory = (accessories.Find(x => x.Id == item.ItemRefId));
                }
                else if (item.ItemType == ItemType.Bill)
                {
                    item.Bill = (bills.Find(x => x.Id == item.ItemRefId));
                }
                else if (item.ItemType == ItemType.Companent)
                {
                    item.Component = (components.Find(x => x.Id == item.ItemRefId));
                }
                else if (item.ItemType == ItemType.Fixture)
                {
                    item.Fixture = (fixtures.Find(x => x.Id == item.ItemRefId));
                }
                else if (item.ItemType == ItemType.Licence)
                {
                    item.Licence = (licenses.Find(x => x.Id == item.ItemRefId));
                }
                else if (item.ItemType == ItemType.Toner)
                {
                    item.Toner = (toners.Find(x => x.Id == item.ItemRefId));
                }
            }

            return result;
        }

        public UltimateSetResult AddItemHistory(ItemHistory parameter)
        {
            return itemHistory.AddItemHistory(parameter);
        }

    }
}
