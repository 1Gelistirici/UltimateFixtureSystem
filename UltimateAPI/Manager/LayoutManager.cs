using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class LayoutManager : BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile LayoutManager _instance;
        public static LayoutManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new LayoutManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<Layout>> GetMenus()
        {
            List<Layout> layouts = new List<Layout>();
            UltimateResult<List<Layout>> result = new UltimateResult<List<Layout>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[menu_GetMenus]";

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
                                    Layout layout = new Layout();
                                    layout.Id = Convert.ToInt32(read["id"]);
                                    layout.Name = read["name"].ToString();
                                    layout.Url = read["url"].ToString();
                                    layout.Area = read["area"].ToString();
                                    layout.Icon = read["icon"].ToString();
                                    layout.Dependency = read["dependency"].ToString();

                                    layouts.Add(layout);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = layouts;
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
