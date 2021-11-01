using System.Data.SqlClient;

namespace UltimateAPI.Manager
{
    public static class Global
    {
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(@"Data Source=YAZ31;Initial Catalog=UDemirbas;Integrated Security=True");
            //@"Data Source=SKY-NET\SQLEXPRESS;Initial Catalog=UDemirbas;Integrated Security=True"
        }
    }
}
