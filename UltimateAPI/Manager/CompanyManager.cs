using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class CompanyManager
    {
        public UltimateResult<List<Company>> GetCompanies()
        {
            List<Company> datas = new List<Company>();
            UltimateResult<List<Company>> result = new UltimateResult<List<Company>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[companies_GetCompanies]";

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
                                    Company data = new Company();
                                    data.Id = Convert.ToInt32(read["id"]);
                                    data.Name = Convert.ToString(read["Company"]);
                                    data.ParentRefId = Convert.ToInt32(read["ParentRefId"]);
                                    data.LogoUrl = Convert.ToString(read["LogoUrl"].ToString());
                                    data.EstablishmentDate = Convert.ToDateTime(read["EstablishmentDate"].ToString());
                                    data.InsertDate = Convert.ToDateTime(read["InsertDate"].ToString());

                                    datas.Add(data);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = datas;
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

        public UltimateResult<Company> GetCompany(ReferansParameter parameter)
        {
            Company data = new Company();
            UltimateResult<Company> result = new UltimateResult<Company>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[companies_GetCompany]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();
                        sqlCommand.Parameters.AddWithValue("@Id", parameter.RefId);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    data.Id = Convert.ToInt32(read["id"]);
                                    data.Name = Convert.ToString(read["Company"]);
                                    data.ParentRefId = Convert.ToInt32(read["ParentRefId"]);
                                    data.LogoUrl = Convert.ToString(read["LogoUrl"].ToString());
                                    data.EstablishmentDate = Convert.ToDateTime(read["EstablishmentDate"].ToString());
                                    data.InsertDate = Convert.ToDateTime(read["InsertDate"].ToString());
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = data;
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

        public UltimateResult<List<Company>> GetCompanyGroup(ReferansParameter parameter)
        {
            List<Company> datas = new List<Company>();
            UltimateResult<List<Company>> result = new UltimateResult<List<Company>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[companies_GetCompanyGroup]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();
                        sqlCommand.Parameters.AddWithValue("@ParentId", parameter.RefId);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    Company data = new Company();
                                    data.Id = Convert.ToInt32(read["id"]);
                                    data.Name = Convert.ToString(read["Company"]);
                                    data.ParentRefId = Convert.ToInt32(read["ParentRefId"]);
                                    data.LogoUrl = Convert.ToString(read["LogoUrl"].ToString());
                                    data.EstablishmentDate = Convert.ToDateTime(read["EstablishmentDate"].ToString());
                                    data.InsertDate = Convert.ToDateTime(read["InsertDate"].ToString());

                                    datas.Add(data);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = datas;
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

        public UltimateSetResult DeleteCompany(ReferansParameter parameter)
        {
            UltimateSetResult result = new UltimateSetResult();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[companies_DeleteCompany]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@Id", parameter.RefId);

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

        public UltimateSetResult AddCompany(Company parameter)
        {
            UltimateSetResult result = new UltimateSetResult();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[companies_AddCompany]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@Name", parameter.Name);
                        sqlCommand.Parameters.AddWithValue("@LogoUrl", parameter.LogoUrl);
                        sqlCommand.Parameters.AddWithValue("@EstablishmentDate", parameter.EstablishmentDate);

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

        public UltimateSetResult UpdateCompany(Company parameter)
        {
            UltimateSetResult result = new UltimateSetResult();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[companies_UpdateCompany]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@Id", parameter.Id);
                        sqlCommand.Parameters.AddWithValue("@Name", parameter.Name);
                        sqlCommand.Parameters.AddWithValue("@LogoUrl", parameter.LogoUrl);
                        sqlCommand.Parameters.AddWithValue("@EstablishmentDate", parameter.EstablishmentDate);

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
    }
}
