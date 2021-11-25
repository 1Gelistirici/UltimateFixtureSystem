using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class DepartmentManager : BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile DepartmentManager _instance;
        public static DepartmentManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DepartmentManager();
                        }
                    }
                }
                return _instance;
            }

        }


        public UltimateResult<List<Department>> GetDepartments(Department parameter)
        {
            List<Department> departments = new List<Department>();
            UltimateResult<List<Department>> result = new UltimateResult<List<Department>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[departments_GetDepartments]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();
                        sqlCommand.Parameters.AddWithValue("@companyId", parameter.CompanyId);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    Department department = new Department();
                                    department.Id = Convert.ToInt32(read["id"]);
                                    department.CompanyId = Convert.ToInt32(read["companyId"].ToString());
                                    department.Name = read["name"].ToString();

                                    departments.Add(department);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = departments;
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
