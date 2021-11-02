using System.Data.SqlClient;

namespace UltimateAPI.Manager
{
    public static class Global
    {
        public static SqlConnection GetSqlConnection()
        {
            string MachineName = System.Net.Dns.GetHostName();
            if (MachineName == "yaz31")
            {
                return new SqlConnection(@"Data Source=YAZ31;Initial Catalog=UDemirbas;Integrated Security=True");
            }

            return new SqlConnection(@"Data Source=SKY-NET\SQLEXPRESS;Initial Catalog=UDemirbas;Integrated Security=True");
        }
    }
}
