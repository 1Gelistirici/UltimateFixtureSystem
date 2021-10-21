using System.Data.SqlClient;

namespace UltimateAPI.Manager
{
    public static class Global
    {
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(@"Data Source=.\;Initial Catalog=UDemirbas;Integrated Security=True");
        }
    }
}
