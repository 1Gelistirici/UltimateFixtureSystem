using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class LicenseManager : BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile LicenseManager _instance;
        public static LicenseManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new LicenseManager();
                        }
                    }
                }
                return _instance;
            }
        }


        public UltimateResult<List<License>> AddLicense(License parameter)
        {
            List<License> licensesTypes = new List<License>();
            UltimateResult<List<License>> result = new UltimateResult<List<License>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[licanses_AddLicances]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@CompanyRefId", parameter.CompanyRefId);
                        sqlCommand.Parameters.AddWithValue("@license", parameter.Name);
                        sqlCommand.Parameters.AddWithValue("@typeNo", parameter.TypeNo);
                        sqlCommand.Parameters.AddWithValue("@piece", parameter.Piece);

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

            AddLog(parameter.UserId, "Lisans eklendi");

            return result;
        }

        public UltimateResult<List<License>> GetLicenses()
        {
            List<License> licenses = new List<License>();
            UltimateResult<List<License>> result = new UltimateResult<List<License>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[licanses_GetLicenses]";

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
                                    License license = new License();
                                    license.Id = Convert.ToInt32(read["id"]);
                                    license.Name = read["license"].ToString();
                                    license.TypeNo = read["type_no"].ToString();
                                    license.Type = read["licanceTypeName"].ToString();
                                    license.Piece = Convert.ToInt32(read["piece"]);

                                    licenses.Add(license);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = licenses;
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

        public UltimateResult<List<License>> DeleteLicense(License parameter)
        {
            UltimateResult<List<License>> result = new UltimateResult<List<License>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[licanses_DeleteLicense]";

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
                result.IsSuccess = false;
                return result;
            }

            AddLog(parameter.UserId, "Lisans Silindi");

            return result;
        }

        public UltimateResult<List<License>> UpdateLicense(License parameter)
        {
            UltimateResult<List<License>> result = new UltimateResult<List<License>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[licanses_UpdateLicense]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@Id", parameter.Id);
                        sqlCommand.Parameters.AddWithValue("@licanse", parameter.Name);
                        sqlCommand.Parameters.AddWithValue("@typeNo", parameter.TypeNo);
                        sqlCommand.Parameters.AddWithValue("@piece", parameter.Piece);

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

            AddLog(parameter.UserId, "Lisans Güncellendi");

            return result;
        }

        public UltimateResult<List<License>> GetLicenceByCompanyRefId(ReferansParameter parameter)
        {
            List<License> licenses = new List<License>();
            UltimateResult<List<License>> result = new UltimateResult<List<License>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[licanses_GetLicenceByCompanyRefId]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();
                        sqlCommand.Parameters.AddWithValue("@CompanyRefId", parameter.CompanyId);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    License license = new License();
                                    license.Id = Convert.ToInt32(read["id"]);
                                    license.Name = read["license"].ToString();
                                    license.TypeNo = read["type_no"].ToString();
                                    license.Type = read["licanceTypeName"].ToString();
                                    license.Piece = Convert.ToInt32(read["piece"]);

                                    licenses.Add(license);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = licenses;
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
