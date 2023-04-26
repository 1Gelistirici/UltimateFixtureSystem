using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;
using UltimateAPI.Entities.Enums;

namespace UltimateAPI.Manager
{
    public class ItemHistoryManager : BaseManager
    {
        public UltimateResult<List<ItemHistory>> GetItemHistoryByCompany(ReferansParameter parameter)
        {
            List<ItemHistory> datas = new List<ItemHistory>();
            UltimateResult<List<ItemHistory>> result = new UltimateResult<List<ItemHistory>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[itemHistory_GetItemHistoryByCompany]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@CompanyRefId", parameter.RefId);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    ItemHistory itemHistory = new ItemHistory();
                                    itemHistory.Id = Convert.ToInt32(read["Id"]);
                                    itemHistory.ItemRefId = Convert.ToInt32(read["ItemRefId"]);
                                    itemHistory.ItemType = (ItemType)Convert.ToInt32(read["ItemType"]);
                                    itemHistory.ProcessType = (ProcessType)Convert.ToInt32(read["ProcessType"]);
                                    itemHistory.TransactionUserRefId = Convert.ToInt32(read["TransactionUserRefId"]);
                                    itemHistory.CommittedUserRefId = Convert.ToInt32(read["CommittedUserRefId"]);

                                    datas.Add(itemHistory);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = datas;
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

        public UltimateSetResult AddItemHistory(ItemHistory parameter)
        {
            UltimateSetResult result = new UltimateSetResult();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[itemHistory_AddItemHistory]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@ItemRefId", parameter.ItemRefId);
                        sqlCommand.Parameters.AddWithValue("@ItemType", parameter.ItemType);
                        sqlCommand.Parameters.AddWithValue("@ProcessType", parameter.ProcessType);
                        sqlCommand.Parameters.AddWithValue("@TransactionUserRefId", parameter.TransactionUserRefId);
                        sqlCommand.Parameters.AddWithValue("@CommittedUserRefId", parameter.CommittedUserRefId);

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
                result.Message = ex.Message;
                result.IsSuccess = false;
                return result;
            }

            return result;
        }

    }
}
