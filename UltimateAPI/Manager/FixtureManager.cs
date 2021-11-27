using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class FixtureManager : BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile FixtureManager _instance;
        public static FixtureManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new FixtureManager();
                        }
                    }
                }
                return _instance;
            }

        }


        public UltimateResult<List<Fixture>> GetFixtures()
        {
            List<Fixture> fixtures = new List<Fixture>();
            UltimateResult<List<Fixture>> result = new UltimateResult<List<Fixture>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[fixtures_GetFixtures]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
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
                                    Fixture fixture = new Fixture();
                                    fixture.Id = Convert.ToInt32(read["id"]);
                                    fixture.LoginSystem = read["loginSystem"].ToString();
                                    fixture.ModelNo = Convert.ToInt32(read["modelNo"]);
                                    fixture.BillNo = Convert.ToInt32(read["billNo"]);
                                    fixture.StatuNo = Convert.ToInt32(read["statuNo"]);
                                    fixture.CategoryNo = Convert.ToInt32(read["categoryNo"]);
                                    fixture.UserNo = Convert.ToInt32(read["userNo"]);

                                    fixtures.Add(fixture);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = fixtures;
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

        public UltimateResult<List<Fixture>> GetFixture(Fixture parameter)
        {
            List<Fixture> fixtures = new List<Fixture>();
            UltimateResult<List<Fixture>> result = new UltimateResult<List<Fixture>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[fixtures_GetFixture]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@id", parameter.Id);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    Fixture fixture = new Fixture();
                                    fixture.Id = Convert.ToInt32(read["id"]);
                                    fixture.LoginSystem = read["loginSystem"].ToString();
                                    fixture.ModelNo = Convert.ToInt32(read["modelNo"]);
                                    fixture.BillNo = Convert.ToInt32(read["billNo"]);
                                    fixture.StatuNo = Convert.ToInt32(read["statuNo"]);
                                    fixture.CategoryNo = Convert.ToInt32(read["categoryNo"]);
                                    fixture.UserNo = Convert.ToInt32(read["userNo"]);

                                    fixtures.Add(fixture);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = fixtures;
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
        
        public UltimateResult<List<Fixture>> GetFixtureByUser(Fixture parameter)
        {
            List<Fixture> fixtures = new List<Fixture>();
            UltimateResult<List<Fixture>> result = new UltimateResult<List<Fixture>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[fixtures_GetFixtureByUser]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@userNo", parameter.UserNo);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    Fixture fixture = new Fixture();
                                    fixture.Id = Convert.ToInt32(read["id"]);
                                    fixture.LoginSystem = read["loginSystem"].ToString();
                                    fixture.ModelNo = Convert.ToInt32(read["modelNo"]);
                                    fixture.BillNo = Convert.ToInt32(read["billNo"]);
                                    fixture.StatuNo = Convert.ToInt32(read["statuNo"]);
                                    fixture.CategoryNo = Convert.ToInt32(read["categoryNo"]);
                                    fixture.UserNo = Convert.ToInt32(read["userNo"]);

                                    fixtures.Add(fixture);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = fixtures;
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

        public UltimateResult<List<Fixture>> DeleteFixture(Fixture parameter)
        {
            UltimateResult<List<Fixture>> result = new UltimateResult<List<Fixture>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[fixtures_DeleteFixture]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@id", parameter.Id);

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
            }

            AddLog(parameter.UserId, "Demirbaş Silindi");

            return result;
        }

        public UltimateResult<List<Fixture>> AddFixture(Fixture parameter)
        {
            UltimateResult<List<Fixture>> result = new UltimateResult<List<Fixture>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[fixtures_AddFixture]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@name", parameter.Name);
                        sqlCommand.Parameters.AddWithValue("@loginSystem", parameter.LoginSystem);
                        sqlCommand.Parameters.AddWithValue("@model_no", parameter.ModelNo);
                        sqlCommand.Parameters.AddWithValue("@bill_no", parameter.BillNo);
                        sqlCommand.Parameters.AddWithValue("@statu_no", parameter.StatuNo);
                        sqlCommand.Parameters.AddWithValue("@category_no", parameter.CategoryNo);
                        sqlCommand.Parameters.AddWithValue("@user_no", parameter.UserNo);

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

            AddLog(parameter.UserId, $"{parameter.Name} isimli demirbaş eklendi");

            return result;
        }

        public UltimateResult<List<Fixture>> UpdateFixture(Fixture parameter)
        {
            UltimateResult<List<Fixture>> result = new UltimateResult<List<Fixture>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[fixtures_UpdateFixtures]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@id", parameter.Id);
                        sqlCommand.Parameters.AddWithValue("@name", parameter.Name);
                        sqlCommand.Parameters.AddWithValue("@loginSystem", parameter.LoginSystem);
                        sqlCommand.Parameters.AddWithValue("@model_no", parameter.ModelNo);
                        sqlCommand.Parameters.AddWithValue("@bill_no", parameter.BillNo);
                        sqlCommand.Parameters.AddWithValue("@statu_no", parameter.StatuNo);
                        sqlCommand.Parameters.AddWithValue("@category_no", parameter.CategoryNo);
                        sqlCommand.Parameters.AddWithValue("@user_no", parameter.UserNo);

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

            AddLog(parameter.UserId, $"{parameter.Name} isimli demirbaş güncellenmiştir.");

            return result;
        }

    }
}
