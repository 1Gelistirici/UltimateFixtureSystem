using System;
using System.Data.SqlClient;
using UltimateAPI.Entities;
namespace UltimateAPI.Manager
{
    public class CodeManager : BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile CodeManager _instance;
        public static CodeManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new CodeManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<Code> GetCode(Code parameter)
        {
            UltimateResult<Code> result = new UltimateResult<Code>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[codes_GetCode]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@UserRefId", parameter.UserRefId);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    Code code = new Code();
                                    code.Id = Convert.ToInt32(read["Id"]);
                                    code.UserRefId = Convert.ToInt32(read["UserRefId"]);
                                    code.CodeString = read["CodeString"].ToString();
                                    code.InsertDate = Convert.ToDateTime(read["InsertDate"]);
                                    code.EndDate = Convert.ToDateTime(read["EndDate"]);

                                    result.Data = code;
                                }
                            }
                            read.Close();
                        }
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

        public bool AddCode(Code parameter)
        {
            bool result = false;
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[codes_AddCode]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@UserRefId", parameter.UserRefId);
                        sqlCommand.Parameters.AddWithValue("@Code", parameter.CodeString);
                        sqlCommand.Parameters.AddWithValue("@InsertDate", DateTime.Now);
                        sqlCommand.Parameters.AddWithValue("@EndDate", DateTime.Now.AddMinutes(5));

                        int effectedRow = sqlCommand.ExecuteNonQuery();
                        result = effectedRow > 0;
                        sqlConnection.Close();
                        sqlCommand.Dispose();

                    }
                    ConnectionManager.Instance.Dispose(sqlConnection);
                }
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.Excep(ex, sqlConnection);
                return false;
            }

            return result;
        }
    }
}