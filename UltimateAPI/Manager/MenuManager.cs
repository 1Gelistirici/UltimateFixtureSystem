using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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






    }
}
