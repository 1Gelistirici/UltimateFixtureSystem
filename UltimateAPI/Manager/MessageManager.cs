using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class MessageManager : BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile MessageManager _instance;
        public static MessageManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new MessageManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<Message>> GetMessages(Message parameter)
        {
            List<Message> messages = new List<Message>();
            UltimateResult<List<Message>> result = new UltimateResult<List<Message>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[messages_GetMessages]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        User param = new User();
                        param.UserId = parameter.UserId;
                        sqlCommand.Parameters.AddWithValue("@company", UserManager.Instance.GetUser(param).Data[0].Company);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    Message message = new Message();
                                    message.Id = Convert.ToInt32(read["id"]);
                                    message.UserName = read["username"].ToString();
                                    message.Time = Convert.ToDateTime(read["time"]);
                                    message.Name = read["name"].ToString();
                                    message.Surname = read["surname"].ToString();
                                    message.MessageDetail = read["message"].ToString();
                                    message.UserId =Convert.ToInt32(read["userNo"]);

                                    messages.Add(message);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = messages;
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

        public UltimateResult<List<Message>> AddMessage(Message parameter)
        {
            UltimateResult<List<Message>> result = new UltimateResult<List<Message>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[messages_AddMessage]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@UserNo", parameter.UserId);
                        sqlCommand.Parameters.AddWithValue("@message", parameter.MessageDetail);
                        sqlCommand.Parameters.AddWithValue("@time", DateTime.Now);

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

            AddLog(parameter.UserId, "Mesaj Eklendi");

            return result;
        }

        public UltimateResult<List<Message>> DeleteMessage(Message parameter)
        {
            UltimateResult<List<Message>> result = new UltimateResult<List<Message>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[messages_DeleteMessage]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@id", parameter.UserId);

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

            AddLog(parameter.UserId, "Mesaj Silindi");

            return result;
        }

    }
}
