using System.Collections.Generic;
using System.Linq;
using UltimateAPI.Entities;
using UltimateAPI.Entities.Enums;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class BillCallManager
    {
        public UltimateResult<List<Bill>> GetBills()
        {
            UltimateResult<List<Bill>> result = BillManager.Instance.GetBills();
            GetBillItems(ref result);

            return result;
        }

        public UltimateResult<List<Bill>> DeleteBill(Bill parameter)
        {
            Bill bill = GetBills().Data.Where(x => x.Id == parameter.Id).ToList()[0];
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

        private void GetBillItems(ref UltimateResult<List<Bill>> data)
        {
            List<Accessory> accessories = AccessoryManager.Instance.GetAccessories().Data.ToList();
            List<Fixture> fixtures = FixtureManager.Instance.GetFixtures().Data.ToList();
            List<Component> components = ComponentManager.Instance.GetComponents().Data.ToList();

            List<AccessoryModel> accessoryModels = AccessoryModelManager.Instance.GetAccessoryModels().Data.ToList();
            List<FixtureModel> fixtureModels = FixtureModelManager.Instance.GetFixtureModels().Data.ToList();
            List<ComponentModel> componentModels = ComponentModelManager.Instance.GetComponentModels().Data.ToList();

            for (int i = 0; i < data.Data.Count - 1; i++)
            {
                int billRefId = data.Data[i].Id;
                List<Accessory> accessoriesFilter = accessories.Where(x => x.BillNo == billRefId).ToList();
                List<Fixture> fixturesFilter = fixtures.Where(x => x.BillNo == billRefId).ToList();
                List<Component> componentsFilter = components.Where(x => x.BillNo == billRefId).ToList();

                if (data.Data[i].Items == null)
                {
                    data.Data[i].Items = new List<BillItem>();
                }

                foreach (Accessory item in accessoriesFilter)
                {
                    AccessoryModel accessoryModel = accessoryModels.Find(x => x.Id == item.ModelNo);

                    data.Data[i].Items.Add(new BillItem() { Name = item.Name, Piece = item.Piece, Price = item.Price, ProductType = ProductType.Accessory, ModelRefId = item.ModelNo, CategoryRefId = item.CategoryNo, Model = accessoryModel });
                }
                foreach (Fixture item in fixturesFilter)
                {
                    FixtureModel fixtureModel = fixtureModels.Find(x => x.Id == item.ModelNo);

                    data.Data[i].Items.Add(new BillItem() { Name = item.Name, Price = item.Price, ProductType = ProductType.Fixture, ModelRefId = item.ModelNo, CategoryRefId = item.CategoryNo, Model = fixtureModel });
                }
                foreach (Component item in componentsFilter)
                {
                    ComponentModel componentModel = componentModels.Find(x => x.Id == item.ModelNo);

                    data.Data[i].Items.Add(new BillItem() { Name = item.Name, Piece = item.Piece, Price = item.Price, ProductType = ProductType.Component, ModelRefId = item.ModelNo, CategoryRefId = item.CategoryNo, Model = componentModel });
                }

            }
        }

        public UltimateResult<List<BillItem>> DeleteBillItem(ReferansParameter parameter)
        {
            return BillManager.Instance.DeleteBillItem(parameter);
        }

    }
}
