using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class MenuManager : BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile MenuManager _instance;
        public static MenuManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new MenuManager();
                        }
                    }
                }
                return _instance;
            }
        }


        public UltimateResult<List<Menu>> GetMenus()
        {
            List<Menu> menus = new List<Menu>();
            UltimateResult<List<Menu>> result = new UltimateResult<List<Menu>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[menu_GetMenus]";

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
                                    Menu menu = new Menu();
                                    menu.Id = Convert.ToInt32(read["id"]);
                                    menu.Name = read["name"].ToString();
                                    menu.Url = read["url"].ToString();
                                    menu.Icon = read["icon"].ToString();
                                    menu.Dependency = Convert.ToInt16(read["dependency"]);
                                    menu.Order = Convert.ToInt16(read["order"]);

                                    menus.Add(menu);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = menus;
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


        public UltimateResult<List<Menu>> AddMenu(Menu parameter)
        {
            UltimateResult<List<Menu>> result = new UltimateResult<List<Menu>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[menu_AddMenu]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();
                        sqlCommand.Parameters.AddWithValue("name", parameter.Name);
                        sqlCommand.Parameters.AddWithValue("url", parameter.Url);
                        sqlCommand.Parameters.AddWithValue("icon", parameter.Icon);
                        sqlCommand.Parameters.AddWithValue("dependency", parameter.Dependency);
                        sqlCommand.Parameters.AddWithValue("order", parameter.Order);
                        sqlCommand.Parameters.AddWithValue("@ResultId", SqlDbType.Int).Direction = ParameterDirection.Output;


                        int effectedRow = sqlCommand.ExecuteNonQuery();
                        result.IsSuccess = effectedRow > 0;
                        result.ReturnId = (int)sqlCommand.Parameters["@ResultId"].Value;
                        sqlConnection.Close();
                        sqlCommand.Dispose();

                    }
                    ConnectionManager.Instance.Dispose(sqlConnection);

                    if (result.IsSuccess)
                    {
                        UserRoleManager.Instance.AddRole(new UserRole() { UserRefId = 3, MenuRefId = result.ReturnId });
                    }
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

        public UltimateResult<List<Menu>> DeleteMenu(Menu parameter)
        {
            UltimateResult<List<Menu>> result = new UltimateResult<List<Menu>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[menu_DeleteMenu]";

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

                    
                        if (result.IsSuccess)
                        {
                            //    UltimateResult<List<Menu>> menus = GetMenus();
                            //    menus.Data = menus.Data.Where(x => x.Dependency == parameter.Id).ToList();
                            //    foreach (var item in menus.Data)
                            //    {
                            //        DeleteMenu(new Menu { Id = item.Id });
                            //    }

                            UserRoleManager.Instance.DeleteRole(new UserRole() {MenuRefId=parameter.Id });
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

            return result;
        }

        public UltimateResult<List<Menu>> UpdateMenu(Menu parameter)
        {
            UltimateResult<List<Menu>> result = new UltimateResult<List<Menu>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[menu_UpdateMenu]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@id", parameter.Id);
                        sqlCommand.Parameters.AddWithValue("name", parameter.Name);
                        sqlCommand.Parameters.AddWithValue("url", parameter.Url);
                        sqlCommand.Parameters.AddWithValue("icon", parameter.Icon);
                        sqlCommand.Parameters.AddWithValue("dependency", parameter.Dependency);
                        sqlCommand.Parameters.AddWithValue("order", parameter.Order);

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

            return result;
        }


    }
}
