﻿using System.Collections.Generic;
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
            if (result.IsSuccess)
            {
                GetBillItems(ref result);
            }

            return result;
        }

        public UltimateResult<List<Bill>> DeleteBill(Bill parameter)
        {

            Bill bill = GetBills().Data.Where(x => x.Id == parameter.Id).ToList()[0];
            if (bill.Items != null)
            {
                bool isHaveItem = bill.Items.Count > 0;

                if (isHaveItem)
                {
                    UltimateResult<List<Bill>> result = new UltimateResult<List<Bill>>();
                    result.IsSuccess = false;
                    result.Message = "Fatura silinemedi. Faturaya ait ürünler bulunmaktadır.";
                    return result;
                }
            }

            return BillManager.Instance.DeleteBill(parameter);
        }

        public UltimateResult<List<Bill>> AddBill(Bill parameter)
        {
            return BillManager.Instance.AddBill(parameter);
        }

        public UltimateResult<List<Bill>> GetBillByCompanyRefId(ReferansParameter parameter)
        {
            return BillManager.Instance.GetBillByCompanyRefId(parameter);
        }

        public UltimateResult<List<Bill>> UpdateBill(Bill parameter)
        {
            return BillManager.Instance.UpdateBill(parameter);
        }

        private void GetBillItems(ref UltimateResult<List<Bill>> resultData)
        {
            try
            {

                List<Accessory> accessories = AccessoryManager.Instance.GetAccessories().Data.ToList();
                List<Fixture> fixtures = FixtureManager.Instance.GetFixtures().Data.ToList();
                List<Component> components = ComponentManager.Instance.GetComponents().Data.ToList();

                TonerCallManager tonerCallManager = new TonerCallManager();
                List<Toner> toners = tonerCallManager.GetToners().Data.ToList();

                List<AccessoryModel> accessoryModels = AccessoryModelManager.Instance.GetAccessoryModels().Data.ToList();
                List<FixtureModel> fixtureModels = FixtureModelManager.Instance.GetFixtureModels().Data.ToList();
                List<ComponentModel> componentModels = ComponentModelManager.Instance.GetComponentModels().Data.ToList();

                for (int i = 0; i < resultData.Data.Count; i++)
                {
                    int billRefId = resultData.Data[i].Id;
                    List<Accessory> accessoriesFilter = accessories.Where(x => x.BillNo == billRefId).ToList();
                    List<Fixture> fixturesFilter = fixtures.Where(x => x.BillNo == billRefId).ToList();
                    List<Component> componentsFilter = components.Where(x => x.BillNo == billRefId).ToList();
                    List<Toner> tonersFilter = toners.Where(x => x.BillRefId == billRefId).ToList();

                    if (resultData.Data[i].Items == null)
                    {
                        resultData.Data[i].Items = new List<BillItem>();
                    }

                    foreach (Accessory item in accessoriesFilter)
                    {
                        AccessoryModel accessoryModel = accessoryModels.Find(x => x.Id == item.ModelNo);

                        resultData.Data[i].Items.Add(new BillItem() { Id = item.Id, Name = item.Name, Piece = item.Piece, Price = item.Price, ProductType = ProductType.Accessory, ModelRefId = item.ModelNo, CategoryRefId = item.CategoryNo, Model = accessoryModel, BillRefId = resultData.Data[i].Id });
                    }
                    foreach (Fixture item in fixturesFilter)
                    {
                        FixtureModel fixtureModel = fixtureModels.Find(x => x.Id == item.ModelNo);

                        resultData.Data[i].Items.Add(new BillItem() { Id = item.Id, Name = item.Name, Price = item.Price, ProductType = ProductType.Fixture, ModelRefId = item.ModelNo, CategoryRefId = item.CategoryNo, Model = fixtureModel, BillRefId = resultData.Data[i].Id });
                    }
                    foreach (Component item in componentsFilter)
                    {
                        ComponentModel componentModel = componentModels.Find(x => x.Id == item.ModelNo);

                        resultData.Data[i].Items.Add(new BillItem() { Id = item.Id, Name = item.Name, Piece = item.Piece, Price = item.Price, ProductType = ProductType.Component, ModelRefId = item.ModelNo, CategoryRefId = item.CategoryNo, Model = componentModel, BillRefId = resultData.Data[i].Id });
                    }
                    foreach (Toner item in tonersFilter)
                    {
                        resultData.Data[i].Items.Add(new BillItem() { Id = item.Id, Name = item.Name, Piece = item.Piece, Price = item.Price, ProductType = ProductType.Toner, BillRefId = resultData.Data[i].Id, Boundary = item.Piece, MinStock = item.Piece });
                    }
                }

            }
            catch (System.Exception ex)
            {
                throw;
            }

        }

        public UltimateResult<List<BillItem>> DeleteBillItem(BillItem billItem)
        {
            UltimateResult<List<BillItem>> result = new UltimateResult<List<BillItem>>();

            Bill bill = GetBills().Data.ToList().Find(x => x.Id == billItem.BillRefId);
            bill.Price = bill.Price - billItem.Price;
            UltimateResult<List<Bill>> billResult = UpdateBill(bill);

            if (billResult.IsSuccess)
            {
                if (billItem.ProductType == ProductType.Accessory)
                {
                    AccessoryCallManager accessoryCallManager = new AccessoryCallManager();
                    result.IsSuccess = accessoryCallManager.DeleteAccessory(new Accessory() { Id = billItem.Id }).IsSuccess;
                }
                else if (billItem.ProductType == ProductType.Component)
                {
                    ComponentCallManager componentCallManager = new ComponentCallManager();
                    result.IsSuccess = componentCallManager.DeleteComponent(new Component() { Id = billItem.Id }).IsSuccess;
                }
                else if (billItem.ProductType == ProductType.Fixture)
                {
                    result.IsSuccess = FixtureCallManager.Instance.DeleteFixture(new Fixture() { Id = billItem.Id }).IsSuccess;
                }
                else if (billItem.ProductType == ProductType.Toner)
                {
                    TonerCallManager tonerCallManager = new TonerCallManager();
                    result.IsSuccess = tonerCallManager.DeleteToner(new Toner() { Id = billItem.Id }).IsSuccess;
                }
            }

            return result;
        }

        public UltimateResult<BillItem> AddBillItem(BillItem parameter)
        {
            UltimateResult<BillItem> result = new UltimateResult<BillItem>();

            Bill bill = GetBills().Data.ToList().Find(x => x.Id == parameter.BillRefId);
            bill.Price = bill.Price + parameter.Price;
            UltimateResult<List<Bill>> billResult = UpdateBill(bill);

            if (billResult.IsSuccess)
            {
                if (parameter.ProductType == ProductType.Accessory)
                {
                    Accessory accessory = new Accessory();
                    accessory.Name = parameter.Name;
                    accessory.Piece = parameter.Piece;
                    accessory.Price = parameter.Price;
                    accessory.ModelNo = parameter.ModelRefId;
                    accessory.UserNo = parameter.Id;
                    accessory.BillNo = parameter.BillRefId;
                    accessory.StatuNo = (int)ItemStatu.Ready;
                    accessory.CategoryNo = parameter.CategoryRefId;

                    AccessoryCallManager accessoryCallManager = new AccessoryCallManager();
                    var resultItem = accessoryCallManager.AddAccessory(accessory);

                    result.IsSuccess = resultItem.IsSuccess;
                    result.Message = resultItem.Message;
                    result.ReturnId = resultItem.ReturnId;
                }
                else if (parameter.ProductType == ProductType.Component)
                {
                    Component component = new Component();
                    component.Name = parameter.Name;
                    component.Piece = parameter.Piece;
                    component.Price = parameter.Price;
                    component.ModelNo = parameter.ModelRefId;
                    component.BillNo = parameter.BillRefId;
                    component.CategoryNo = parameter.CategoryRefId;

                    ComponentCallManager componentCallManager = new ComponentCallManager();
                    var resultItem = componentCallManager.AddComponent(component);

                    result.IsSuccess = resultItem.IsSuccess;
                    result.Message = resultItem.Message;
                    result.ReturnId = resultItem.ReturnId;
                }
                else if (parameter.ProductType == ProductType.Fixture)
                {
                    for (int i = 0; i < parameter.Piece; i++)
                    {
                        Fixture fixture = new Fixture();
                        fixture.Name = parameter.Name;
                        fixture.ModelNo = parameter.ModelRefId;
                        fixture.BillNo = parameter.BillRefId;
                        fixture.StatuNo = (int)ItemStatu.Ready;
                        fixture.CategoryNo = parameter.CategoryRefId;
                        fixture.Price = parameter.Price;

                        var resultItem = FixtureCallManager.Instance.AddFixture(fixture);

                        result.IsSuccess = resultItem.IsSuccess;
                        result.Message = resultItem.Message;
                        result.ReturnId = resultItem.ReturnId;
                    }
                }
                else if (parameter.ProductType == ProductType.Toner)
                {
                    Toner toner = new Toner();
                    toner.Name = parameter.Name;
                    toner.Piece = parameter.Piece;
                    toner.Price = parameter.Price;
                    toner.Boundary = parameter.Piece;
                    toner.MinStock = parameter.Piece;
                    toner.BillRefId = parameter.BillRefId;

                    TonerCallManager tonerCallManager = new TonerCallManager();
                    var resultItem = tonerCallManager.AddToner(toner);

                    result.IsSuccess = resultItem.IsSuccess;
                    result.Message = resultItem.Message;
                    result.ReturnId = resultItem.ReturnId;
                }

            }

            return result;
        }


    }
}
