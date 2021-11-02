using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class TokenManager
    {
        private static readonly object Lock = new object();
        private static volatile TokenManager _instance;
        public static TokenManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new TokenManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<User>> GenerateToken(User user)
        {
            SqlConnection sqlConnection = null;
            UltimateResult<List<User>> result = new UltimateResult<List<User>>();
            string Proc = "[dbo].[GenerateToken]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@id", user.Id);
                        sqlCommand.Parameters.AddWithValue("@token", user.Token);

                        int effectedRow = sqlCommand.ExecuteNonQuery();

                        result.IsSuccess = effectedRow > 0;
                        sqlConnection.Close();

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
