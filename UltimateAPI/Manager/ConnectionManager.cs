using System;
using System.Data;
using System.Data.SqlClient;

namespace UltimateAPI.Manager
{
    public class ConnectionManager : BaseManager
    {

        private static readonly object Lock = new object();
        private static volatile ConnectionManager _instance;

        private static SqlCommand sqlCommand;

        public static ConnectionManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ConnectionManager();
                        }
                    }
                }
                return _instance;
            }

        }


        public SqlCommand Command(string proc, SqlConnection sqlCon)
        {
            sqlCommand = new SqlCommand(proc, sqlCon);
            return sqlCommand;
        }

        public void SqlConnect(SqlConnection sqlCon)
        {
            if (sqlCon.State == ConnectionState.Broken)
            {
                sqlCon.Close();
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
        }

        public void Excep(Exception ex, SqlConnection sqlcon)
        {
            if (sqlcon != null)
            {
                sqlcon.Close();
            }

            Error(ex);
        }

        public void CmdOperations()
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Clear();
        }

        public void Dispose(SqlConnection sqlcon)
        {
            sqlcon.Close();
            sqlcon.Dispose();
        }

        //public static SqlConnection GetSqlConnection(string Adress)
        //{
        //    sqlConnection = new SqlConnection(Adress);

        //    if (sqlConnection.State == ConnectionState.Broken)
        //    {
        //        sqlConnection.Close();
        //    }

        //    if (sqlConnection.State == ConnectionState.Closed)
        //    {
        //        sqlConnection.Open();
        //    }

        //    return sqlConnection;
        //}

        //public void Dispose()
        //{
        //    sqlConnection.Dispose();
        //    sqlConnection.Close();
        //}

        //public static SqlCommand command(string proc)
        //{
        //    sqlCommand = new SqlCommand(proc, sqlConnection);
        //    return sqlCommand;
        //}


    }
}
