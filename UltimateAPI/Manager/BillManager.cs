using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using UltimateAPI.Entities;
using UltimateAPI.Entities.Enums;

namespace UltimateAPI.Manager
{
    public class BillManager : BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile BillManager _instance;
        public static BillManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new BillManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<Bill>> GetBills()
        {
            List<Bill> bills = new List<Bill>();
            UltimateResult<List<Bill>> result = new UltimateResult<List<Bill>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[bills_GetBills]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    Bill bill = new Bill();
                                    bill.Id = Convert.ToInt32(read["id"]);
                                    bill.BillNo = read["billNo"].ToString();
                                    bill.BillDate = Convert.ToDateTime(read["billDate"]);
                                    bill.InsertDate = Convert.ToDateTime(read["insertDate"]);
                                    bill.Price = Convert.ToInt32(read["price"]);
                                    bill.Comment = read["comment"].ToString();
                                    bill.Department = Convert.ToInt32(read["department"]);
                                    bill.CompanyId = Convert.ToInt32(read["CompanyrefId"]);

                                    bills.Add(bill);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = bills;
                    }
                    ConnectionManager.Instance.Dispose(sqlConnection);
                }
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.Excep(ex, sqlConnection);
                result.IsSuccess = false;
                return result;
            }

            return result;
        }

        //private List<BillItem> GetBillItems(int billRefId)
        //{
        //    List<BillItem> result = new List<BillItem>();
        //    List<Accessory> accessories = AccessoryManager.Instance.GetAccessories().Data.Where(x => x.BillNo == billRefId).ToList();
        //    List<Fixture> fixtures = FixtureManager.Instance.GetFixtures().Data.Where(x => x.BillNo == billRefId).ToList();
        //    List<Component> components = ComponentManager.Instance.GetComponents().Data.Where(x => x.BillNo == billRefId).ToList();


        //    foreach (Accessory item in accessories)
        //    {
        //        result.Add(new BillItem() { Name = item.Name, Piece = item.Piece, Price = item.Price, ProductType = ProductType.Accessory, ModelRefId = item.ModelNo, CategoryRefId = item.CategoryNo });
        //    }
        //    foreach (Fixture item in fixtures)
        //    {
        //        result.Add(new BillItem() { Name = item.Name, Price = item.Price, ProductType = ProductType.Fixture, ModelRefId = item.ModelNo, CategoryRefId = item.CategoryNo });
        //    }
        //    foreach (Component item in components)
        //    {
        //        result.Add(new BillItem() { Name = item.Name, Piece = item.Piece, Price = item.Price, ProductType = ProductType.Component, ModelRefId = item.ModelNo, CategoryRefId = item.CategoryNo });
        //    }

        //    return result;
        //}

        public UltimateResult<List<Bill>> AddBill(Bill parameter)
        {
            List<Bill> bills = new List<Bill>();
            UltimateResult<List<Bill>> result = new UltimateResult<List<Bill>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[bills_AddBill]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@billNo", parameter.BillNo);
                        sqlCommand.Parameters.AddWithValue("@billDate", parameter.BillDate);
                        sqlCommand.Parameters.AddWithValue("@insertDate", DateTime.Now);
                        sqlCommand.Parameters.AddWithValue("@price", parameter.Price);
                        sqlCommand.Parameters.AddWithValue("@comment", parameter.Comment);
                        sqlCommand.Parameters.AddWithValue("@department", parameter.Department);
                        sqlCommand.Parameters.AddWithValue("@ResultId", SqlDbType.Int).Direction = ParameterDirection.Output;

                        int effectedRow = sqlCommand.ExecuteNonQuery();
                        result.IsSuccess = effectedRow > 0;

                        //Return inserted id
                        int id = (int)sqlCommand.Parameters["@ResultId"].Value;
                        Bill bill = new Bill();
                        bill.Id = id;
                        bills.Add(bill);
                        result.Data = bills;

                        sqlConnection.Close();
                        sqlCommand.Dispose();

                        if (result.IsSuccess)
                        {
                            foreach (var item in parameter.Items)
                            {
                                if (item.ProductType == ProductType.Accessory)
                                {
                                    Accessory accessory = new Accessory();
                                    accessory.Name = item.Name;
                                    accessory.Piece = item.Piece;
                                    accessory.Price = item.Price;
                                    accessory.ModelNo = item.ModelRefId;
                                    accessory.BillNo = bill.Id;
                                    accessory.CategoryNo = item.CategoryRefId;
                                    accessory.UserNo = parameter.UserId;
                                    accessory.StatuNo = (int)ItemStatu.Ready;

                                    AccessoryManager.Instance.AddAccessory(accessory);
                                }
                                else if (item.ProductType == ProductType.Component)
                                {
                                    Component component = new Component();
                                    component.Name = item.Name;
                                    component.Piece = item.Piece;
                                    component.Price = item.Price;
                                    component.BillNo = bill.Id;
                                    component.ModelNo = item.ModelRefId;
                                    component.CategoryNo = item.CategoryRefId;

                                    ComponentManager.Instance.AddComponent(component);
                                }
                                else if (item.ProductType == ProductType.Fixture)
                                {
                                    for (int i = 0; i < item.Piece; i++)
                                    {
                                        Fixture fixture = new Fixture();
                                        fixture.Name = item.Name;
                                        fixture.ModelNo = item.ModelRefId;
                                        fixture.BillNo = bill.Id;
                                        fixture.CategoryNo = item.CategoryRefId;
                                        fixture.Price = item.Price;
                                        fixture.UserNo = parameter.UserId;
                                        fixture.StatuNo = (int)ItemStatu.Ready;

                                        FixtureManager.Instance.AddFixture(fixture);
                                    }
                                }
                                else if (item.ProductType == ProductType.Toner)
                                {
                                    Toner toner = new Toner();
                                    toner.Name = item.Name;
                                    toner.Piece = item.Piece;
                                    toner.Price = item.Price;
                                    toner.Boundary = item.Piece;
                                    toner.MinStock = item.Piece;
                                    toner.BillRefId = bill.Id;

                                    TonerManager.Instance.AddToner(toner);
                                }

                            }


                        }
                    }
                    ConnectionManager.Instance.Dispose(sqlConnection);
                }
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.Excep(ex, sqlConnection);
                result.IsSuccess = false;
                return result;
            }

            AddLog(parameter.UserId, "Toner eklendi");

            return result;
        }

        public UltimateResult<List<Bill>> DeleteBill(Bill parameter)
        {
            UltimateResult<List<Bill>> result = new UltimateResult<List<Bill>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[bills_DeleteBill]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@id", parameter.Id);

                        int effectedRow = sqlCommand.ExecuteNonQuery();
                        result.IsSuccess = effectedRow > 0;
                        sqlConnection.Close();
                        sqlCommand.Dispose();

                    }
                    ConnectionManager.Instance.Dispose(sqlConnection);
                }
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.Excep(ex, sqlConnection);
                result.IsSuccess = false;
                return result;
            }

            AddLog(parameter.UserId, "Fatura Silindi");

            return result;
        }

        public UltimateResult<List<Bill>> UpdateBill(Bill parameter)
        {
            UltimateResult<List<Bill>> result = new UltimateResult<List<Bill>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[bills_UpdateBill]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@id", parameter.Id);
                        sqlCommand.Parameters.AddWithValue("@billNo", parameter.BillNo);
                        sqlCommand.Parameters.AddWithValue("@billDate", parameter.BillDate);
                        sqlCommand.Parameters.AddWithValue("@price", parameter.Price);
                        sqlCommand.Parameters.AddWithValue("@comment", parameter.Comment);
                        sqlCommand.Parameters.AddWithValue("@department", parameter.Department);

                        int effectedRow = sqlCommand.ExecuteNonQuery();
                        result.IsSuccess = effectedRow > 0;
                        sqlConnection.Close();
                        sqlCommand.Dispose();
                    }
                    ConnectionManager.Instance.Dispose(sqlConnection);
                }
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.Excep(ex, sqlConnection);
                result.IsSuccess = false;
                return result;
            }

            AddLog(parameter.UserId, "Fatura Güncellendi");

            return result;
        }

        public UltimateResult<List<Bill>> GetBillByCompanyRefId(ReferansParameter parameter)
        {
            List<Bill> bills = new List<Bill>();
            UltimateResult<List<Bill>> result = new UltimateResult<List<Bill>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[bill_GetBillByCompany]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();
                        sqlCommand.Parameters.AddWithValue("@CompanyRefId", parameter.CompanyId);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    Bill bill = new Bill();
                                    bill.Id = Convert.ToInt32(read["id"]);
                                    bill.BillNo = read["billNo"].ToString();
                                    bill.BillDate = Convert.ToDateTime(read["billDate"]);
                                    bill.InsertDate = Convert.ToDateTime(read["insertDate"]);
                                    bill.Price = Convert.ToInt32(read["price"]);
                                    bill.Comment = read["comment"].ToString();
                                    bill.Department = Convert.ToInt32(read["department"]);
                                    bill.CompanyId = Convert.ToInt32(read["CompanyrefId"]);

                                    bills.Add(bill);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = bills;
                    }
                    ConnectionManager.Instance.Dispose(sqlConnection);
                }
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.Excep(ex, sqlConnection);
                result.IsSuccess = false;
                return result;
            }

            return result;
        }

    }
}
