using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class CategoryManager : BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile CategoryManager _instance;
        public static CategoryManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new CategoryManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<Category>> GetCategories()
        {
            List<Category> categories = new List<Category>();
            UltimateResult<List<Category>> result = new UltimateResult<List<Category>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[categories_GetCategories]";

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
                                    Category category = new Category();
                                    category.Id = Convert.ToInt32(read["id"]);
                                    category.Name = read["categoryName"].ToString();

                                    categories.Add(category);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = categories;
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

        public UltimateResult<List<Category>> AddCategory(Category parameter)
        {
            UltimateResult<List<Category>> result = new UltimateResult<List<Category>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[categories_AddCategory]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@categoryName", parameter.Name);

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

            AddLog(parameter.UserId, "Kategori Eklendi");

            return result;
        }

        public UltimateResult<List<Category>> DeleteCategory(Category parameter)
        {
            UltimateResult<List<Category>> result = new UltimateResult<List<Category>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[categories_DeleteCategory]";

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

            AddLog(parameter.UserId, "Kategori Silindi");

            return result;
        }

        public UltimateResult<List<Category>> UpdateCategory(Category parameter)
        {
            UltimateResult<List<Category>> result = new UltimateResult<List<Category>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[categories_UpdateCategory]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@id", parameter.Id);
                        sqlCommand.Parameters.AddWithValue("@categoryName", parameter.Name);

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

            AddLog(parameter.UserId, "Kategori Güncelle");

            return result;
        }

        public UltimateResult<List<Category>> GetCategoryByCompanyRefId(ReferansParameter parameter)
        {
            List<Category> categories = new List<Category>();
            UltimateResult<List<Category>> result = new UltimateResult<List<Category>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[categories_GetCategoryByCompany]";

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
                                    Category category = new Category();
                                    category.Id = Convert.ToInt32(read["id"]);
                                    category.Name = read["categoryName"].ToString();

                                    categories.Add(category);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = categories;
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
