using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class BillTypeManager : BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile BillTypeManager _instance;
        public static BillTypeManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new BillTypeManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<BillType>> GetBillTypes()
        {
            List<BillType> billTypes = new List<BillType>();
            UltimateResult<List<BillType>> result = new UltimateResult<List<BillType>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[billTypes_GetBillTypes]";

            try
            {
                using (sqlConnection = new SqlConnection(@"Data Source=SKY-NET\SQLEXPRESS;Initial Catalog=UDemirbas;Integrated Security=True"))
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
                                    BillType billType = new BillType();
                                    billType.Id = Convert.ToInt32(read["id"]);
                                    billType.Name = read["typeName"].ToString();

                                    billTypes.Add(billType);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = billTypes;
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

        public UltimateResult<List<BillType>> AddBillType(BillType parameter)
        {
            UltimateResult<List<BillType>> result = new UltimateResult<List<BillType>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[billTypes_AddBillType]";

            try
            {
                using (sqlConnection = new SqlConnection(@"Data Source=SKY-NET\SQLEXPRESS;Initial Catalog=UDemirbas;Integrated Security=True"))
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@typeName", parameter.Name);

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
            
            AddLog(parameter.UserId, "Fatura Tipi Eklendi");

            return result;
        }

        public UltimateResult<List<BillType>> DeleteBillType(BillType parameter)
        {
            UltimateResult<List<BillType>> result = new UltimateResult<List<BillType>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[billTypes_DeleteBillType]";

            try
            {
                using (sqlConnection = new SqlConnection(@"Data Source=SKY-NET\SQLEXPRESS;Initial Catalog=UDemirbas;Integrated Security=True"))
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@Id", parameter.Id);

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

            AddLog(parameter.UserId, "Fatura Tipi Silindi");

            return result;
        }

        public UltimateResult<List<BillType>> UpdateBillType(BillType parameter)
        {
            UltimateResult<List<BillType>> result = new UltimateResult<List<BillType>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[billTypes_UpdateBillType]";

            try
            {
                using (sqlConnection = new SqlConnection(@"Data Source=SKY-NET\SQLEXPRESS;Initial Catalog=UDemirbas;Integrated Security=True"))
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@Id", parameter.Id);
                        sqlCommand.Parameters.AddWithValue("@typeName", parameter.Name);

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

            AddLog(parameter.UserId, "Fatura Tipi Güncellendi");

            return result;
        }
    }
}
