using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class AccessoryManager:BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile AccessoryManager _instance;
        public static AccessoryManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new AccessoryManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<Accessory>> GetAccessories()
        {
            List<Accessory> accessories = new List<Accessory>();
            UltimateResult<List<Accessory>> result = new UltimateResult<List<Accessory>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[accessories_GetAccessories]";

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
                                    Accessory accessory = new Accessory();
                                    accessory.Id = Convert.ToInt32(read["id"]);
                                    accessory.Name = read["name"].ToString();
                                    accessory.Piece = Convert.ToInt32(read["piece"]);
                                    accessory.ModelNo = Convert.ToInt32(read["model_no"]);
                                    accessory.UserNo = Convert.ToInt32(read["user_no"]);
                                    accessory.BillNo = Convert.ToInt32(read["bill_no"]);
                                    accessory.StatuNo = Convert.ToInt32(read["statu_no"]);
                                    accessory.CategoryNo = Convert.ToInt32(read["category_no"]);

                                    accessories.Add(accessory);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = accessories;
                    }
                    ConnectionManager.Instance.Dispose(sqlConnection);
                }
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.Excep(ex, sqlConnection);
                result.IsSuccess = false;
            }

            return result;
        }

        public UltimateResult<List<Accessory>> GetAccessory(Accessory parameter)
        {
            List<Accessory> accessories = new List<Accessory>();
            UltimateResult<List<Accessory>> result = new UltimateResult<List<Accessory>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[accessories_GetAccessory]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@id", parameter.UserId);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    Accessory accessory = new Accessory();
                                    accessory.Id = Convert.ToInt32(read["id"]);
                                    accessory.Name = read["name"].ToString();
                                    accessory.Piece = Convert.ToInt32(read["piece"]);
                                    accessory.ModelNo = Convert.ToInt32(read["model_no"]);
                                    accessory.UserNo = Convert.ToInt32(read["user_no"]);
                                    accessory.BillNo = Convert.ToInt32(read["bill_no"]);
                                    accessory.StatuNo = Convert.ToInt32(read["statu_no"]);
                                    accessory.CategoryNo = Convert.ToInt32(read["category_no"]);

                                    accessories.Add(accessory);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = accessories;
                    }
                    ConnectionManager.Instance.Dispose(sqlConnection);
                }
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.Excep(ex, sqlConnection);
                result.IsSuccess = false;
            }

            return result;
        }

        public UltimateResult<List<Accessory>> AddAccessory(Accessory parameter)
        {
            UltimateResult<List<Accessory>> result = new UltimateResult<List<Accessory>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[accessories_AddAccessory]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@name", parameter.Name);
                        sqlCommand.Parameters.AddWithValue("@piece", parameter.Piece);
                        sqlCommand.Parameters.AddWithValue("@model_no", parameter.ModelNo);
                        sqlCommand.Parameters.AddWithValue("@user_no", parameter.UserNo);
                        sqlCommand.Parameters.AddWithValue("@bill_no", parameter.BillNo);
                        sqlCommand.Parameters.AddWithValue("@statu_no", parameter.StatuNo);
                        sqlCommand.Parameters.AddWithValue("@category_no", parameter.CategoryNo);

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

            AddLog(parameter.UserId, "Aksesuar Eklendi");

            return result;
        }

        public UltimateResult<List<Accessory>> DeleteAccessory(Accessory parameter)
        {
            UltimateResult<List<Accessory>> result = new UltimateResult<List<Accessory>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[accessories_DeleteAccessory]";

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

            AddLog(parameter.UserId, "Aksesuar Silindi");

            return result;
        }

        public UltimateResult<List<Accessory>> UpdateAccessory(Accessory parameter)
        {
            UltimateResult<List<Accessory>> result = new UltimateResult<List<Accessory>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[accessories_UpdateAccessory]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@id", parameter.Id);
                        sqlCommand.Parameters.AddWithValue("@name", parameter.Name);
                        sqlCommand.Parameters.AddWithValue("@piece", parameter.Piece);
                        sqlCommand.Parameters.AddWithValue("@model_no", parameter.ModelNo);
                        sqlCommand.Parameters.AddWithValue("@user_no", parameter.UserNo);
                        sqlCommand.Parameters.AddWithValue("@bill_no", parameter.BillNo);
                        sqlCommand.Parameters.AddWithValue("@statu_no", parameter.StatuNo);
                        sqlCommand.Parameters.AddWithValue("@category_no", parameter.CategoryNo);

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
            }

            AddLog(parameter.UserId, "Aksesuar Güncellendi");

            return result;
        }
    }
}
