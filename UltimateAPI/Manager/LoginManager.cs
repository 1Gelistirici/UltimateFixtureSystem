using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class LoginManager:BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile LoginManager _instance;
        public static LoginManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new LoginManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<User>> Authenticate(User user)
        {
            List<User> users = new List<User>();
            UltimateResult<List<User>> result = new UltimateResult<List<User>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[CheckUser]";

            try
            {
                using (sqlConnection = new SqlConnection(@"Data Source=SKY-NET\SQLEXPRESS;Initial Catalog=UDemirbas;Integrated Security=True"))
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@Company", user.Company);
                        sqlCommand.Parameters.AddWithValue("@UserName", user.UserName);
                        sqlCommand.Parameters.AddWithValue("@Password", user.Password);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    User usr = new User();
                                    usr.Id = Convert.ToInt32(read["Id"]);
                                    usr.Name = read["name"].ToString();
                                    usr.Surname = read["surname"].ToString();

                                    users.Add(usr);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = users;
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
