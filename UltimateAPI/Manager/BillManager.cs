using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UltimateAPI.Entities;

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

    }
}
