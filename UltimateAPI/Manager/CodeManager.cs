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

                        sqlCommand.Parameters.AddWithValue("@Code", parameter.CodeString);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    Code code = new Code();
                                    code.Id = Convert.ToInt32(read["Id"]);
                                    code.UserRefId = Convert.ToInt32(read["UserRefId"]);
                                    code.IpAddress = Convert.ToString(read["IpAddress"]);
                                    code.CodeString = read["Code"].ToString();
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

        public UltimateResult<Code> GetCodeV1(Code parameter)
        {
            UltimateResult<Code> result = new UltimateResult<Code>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[codes_GetCodeV1]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@Code", parameter.CodeString);
                        sqlCommand.Parameters.AddWithValue("@SessionId", parameter.SessionId);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    Code code = new Code();
                                    code.Id = Convert.ToInt32(read["Id"]);
                                    code.UserRefId = Convert.ToInt32(read["UserRefId"]);
                                    code.IpAddress = Convert.ToString(read["IpAddress"]);
                                    code.CodeString = read["Code"].ToString();
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

        public UltimateSetResult DeleteCodeBySessionId(string sessionId)
        {
            UltimateSetResult result = new UltimateSetResult();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[codes_DeleteCodeBySessionId]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@SessionId", sessionId);

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

        public UltimateSetResult IsBlockedByIpAddress(string ipAddress)
        {
            UltimateSetResult result = new UltimateSetResult();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[codes_IsBlockedByIpAddress]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@IpAddress", ipAddress);

                        int effectedRow = sqlCommand.ExecuteNonQuery();
                        result.IsSuccess = effectedRow > 0;

                        if (!result.IsSuccess)
                        {
                            result.Message = "5 dakika içerisinde en fazla 5 doğrulama mesajı atılabilir.";
                        }

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

        public UltimateSetResult IsBlockedBySessionId(string sessionId)
        {
            UltimateSetResult result = new UltimateSetResult();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[codes_IsBlockedBySessionId]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@SessionId", sessionId);

                        int effectedRow = sqlCommand.ExecuteNonQuery();
                        result.IsSuccess = effectedRow > 0;

                        if (!result.IsSuccess)
                        {
                            result.Message = "5 dakika içerisinde en fazla 5 doğrulama mesajı atılabilir.";
                        }

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
                        sqlCommand.Parameters.AddWithValue("@SessionId", parameter.SessionId);
                        sqlCommand.Parameters.AddWithValue("@IpAddress", parameter.IpAddress);
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