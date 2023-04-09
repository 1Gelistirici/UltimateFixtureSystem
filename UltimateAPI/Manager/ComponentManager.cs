using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class ComponentManager : BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile ComponentManager _instance;
        public static ComponentManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ComponentManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<Component>> GetComponents()
        {
            List<Component> components = new List<Component>();
            UltimateResult<List<Component>> result = new UltimateResult<List<Component>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[components_GetComponents]";

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
                                    Component component = new Component();
                                    component.Id = Convert.ToInt32(read["id"]);
                                    component.Name = read["name"].ToString();
                                    component.Piece = Convert.ToInt32(read["piece"]);
                                    component.Price = Convert.ToDouble(read["price"]);
                                    component.ModelNo = Convert.ToInt32(read["model_no"]);
                                    component.BillNo = Convert.ToInt32(read["bill_no"]);
                                    component.CategoryNo = Convert.ToInt32(read["category_no"]);

                                    components.Add(component);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = components;
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

        public UltimateResult<Component> GetComponent(ReferansParameter parameter)
        {
            Component component = new Component();
            UltimateResult<Component> result = new UltimateResult<Component>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[components_GetComponent]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@id", parameter.RefId);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    component.Id = Convert.ToInt32(read["id"]);
                                    component.Name = read["name"].ToString();
                                    component.Piece = Convert.ToInt32(read["piece"]);
                                    component.Price = Convert.ToDouble(read["price"]);
                                    component.ModelNo = Convert.ToInt32(read["model_no"]);
                                    component.BillNo = Convert.ToInt32(read["bill_no"]);
                                    component.CategoryNo = Convert.ToInt32(read["category_no"]);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = component;
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

        public UltimateResult<List<Component>> AddComponent(Component parameter)
        {
            UltimateResult<List<Component>> result = new UltimateResult<List<Component>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[components_AddComponent]";

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
                        sqlCommand.Parameters.AddWithValue("@price", parameter.Price);
                        sqlCommand.Parameters.AddWithValue("@model_no", parameter.ModelNo);
                        sqlCommand.Parameters.AddWithValue("@bill_no", parameter.BillNo);
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

            AddLog(parameter.UserId, "Bileşen Eklendi");

            return result;
        }

        public UltimateResult<List<Component>> DeleteComponent(Component parameter)
        {
            UltimateResult<List<Component>> result = new UltimateResult<List<Component>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[components_DeleteComponent]";

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

            AddLog(parameter.UserId, "Bileşen Silindi");

            return result;
        }

        public UltimateResult<List<Component>> UpdateComponent(Component parameter)
        {
            UltimateResult<List<Component>> result = new UltimateResult<List<Component>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[components_UpdateComponent]";

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
                        sqlCommand.Parameters.AddWithValue("@price", parameter.Price);
                        sqlCommand.Parameters.AddWithValue("@model_no", parameter.ModelNo);
                        sqlCommand.Parameters.AddWithValue("@bill_no", parameter.BillNo);
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

            AddLog(parameter.UserId, "Bileşen Güncellendi");

            return result;
        }
    }
}
