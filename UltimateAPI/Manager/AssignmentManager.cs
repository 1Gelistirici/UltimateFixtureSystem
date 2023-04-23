using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;
using UltimateAPI.Entities.Enums;

namespace UltimateAPI.Manager
{
    public class AssignmentManager : BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile AssignmentManager _instance;
        public static AssignmentManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new AssignmentManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<Assignment>> GetAssignments(Assignment parameter)
        {
            List<Assignment> assignments = new List<Assignment>();
            UltimateResult<List<Assignment>> result = new UltimateResult<List<Assignment>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[assignment_GetAssignments]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    List<Accessory> accessories = AccessoryManager.Instance.GetAccessories().Data;
                    List<Bill> bills = BillManager.Instance.GetBills().Data;
                    List<Component> components = ComponentManager.Instance.GetComponents().Data;
                    List<License> licenses = LicenseManager.Instance.GetLicenses().Data;
                    List<Toner> toners = TonerManager.Instance.GetToners().Data;
                    List<Fixture> fixtures = FixtureManager.Instance.GetFixtures().Data;

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
                                    Assignment assignment = new Assignment();
                                    assignment.Id = Convert.ToInt32(read["id"]);
                                    assignment.UserId = Convert.ToInt32(read["userId"]);
                                    assignment.InsertDate = Convert.ToDateTime(read["insertDate"]);
                                    assignment.AppointerId = Convert.ToInt32(read["appointerId"]);
                                    assignment.ItemType = (ItemType)Convert.ToInt32(read["itemType"]);
                                    assignment.ItemId = Convert.ToInt32(read["itemId"]);
                                    assignment.RecallDate = Convert.ToDateTime(read["recallDate"]);
                                    assignment.Piece = Convert.ToInt32(read["piece"]);
                                    assignment.IsRecall = Convert.ToBoolean(read["isRecall"]);
                                    assignment.Report = Convert.ToBoolean(read["report"]);

                                    if (assignment.ItemType == ItemType.Accessory)
                                    {
                                        assignment.Accessories = (accessories.Find(x => x.Id == assignment.ItemId));
                                    }
                                    else if (assignment.ItemType == ItemType.Bill)
                                    {
                                        assignment.Bills = (bills.Find(x => x.Id == assignment.ItemId));
                                    }
                                    else if (assignment.ItemType == ItemType.Companent)
                                    {
                                        assignment.Components = (components.Find(x => x.Id == assignment.ItemId));
                                    }
                                    else if (assignment.ItemType == ItemType.Fixture)
                                    {
                                        assignment.Fixtures = (fixtures.Find(x => x.Id == assignment.ItemId));
                                    }
                                    else if (assignment.ItemType == ItemType.Licence)
                                    {
                                        assignment.Licences = (licenses.Find(x => x.Id == assignment.ItemId));
                                    }
                                    else if (assignment.ItemType == ItemType.Toner)
                                    {
                                        assignment.Toners = (toners.Find(x => x.Id == assignment.ItemId));
                                    }

                                    assignments.Add(assignment);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = assignments;
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

        public UltimateResult<List<Assignment>> AddAssignment(Assignment parameter)
        {
            UltimateResult<List<Assignment>> result = new UltimateResult<List<Assignment>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[assignment_AddAssignment]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@userId", parameter.UserId);
                        sqlCommand.Parameters.AddWithValue("@appointerId", parameter.AppointerId);
                        sqlCommand.Parameters.AddWithValue("@itemType", parameter.ItemType);
                        sqlCommand.Parameters.AddWithValue("@itemId", parameter.ItemId);
                        sqlCommand.Parameters.AddWithValue("@recallDate", parameter.RecallDate < DateTime.Now ? DateTime.Now : parameter.RecallDate);
                        sqlCommand.Parameters.AddWithValue("@piece", parameter.Piece <= 0 ? 1 : parameter.Piece);
                        sqlCommand.Parameters.AddWithValue("@isRecall", parameter.IsRecall);
                        sqlCommand.Parameters.AddWithValue("@CompanyRefId", parameter.CompanyRefId);

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

            AddLog(parameter.UserId, "Toner eklendi");
            return result;
        }

        public UltimateResult<List<Assignment>> DeleteAssignment(Assignment parameter)
        {
            UltimateResult<List<Assignment>> result = new UltimateResult<List<Assignment>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[assignment_DeleteAssignment]";

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

                        if (result.IsSuccess)
                        {
                            if (parameter.ItemType == ItemType.Accessory)
                            {
                                AccessoryCallManager accessoryCallManager = new AccessoryCallManager();
                                Accessory accessory = accessoryCallManager.GetAccessory(new Accessory() { Id = parameter.ItemId }).Data;

                                accessory.Piece += parameter.Piece;
                                accessoryCallManager.UpdateAccessory(accessory);
                            }
                            else if (parameter.ItemType == ItemType.Companent)
                            {
                                ComponentCallManager componentCallManager = new ComponentCallManager();
                                Component component = componentCallManager.GetComponent(new ReferansParameter() { RefId = parameter.ItemId }).Data;

                                component.Piece += parameter.Piece;

                                componentCallManager.UpdateComponent(component);
                            }
                            else if (parameter.ItemType == ItemType.Fixture)
                            {
                                Fixture fixture = FixtureCallManager.Instance.GetFixture(new Fixture() { Id = parameter.ItemId }).Data;

                                fixture.UserNo = 0;
                                fixture.StatuNo = (int)ItemStatu.Ready;
                                FixtureCallManager.Instance.UpdateFixture(fixture);
                            }
                        }

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

            AddLog(parameter.UserId, "Fatura Silindi");
            return result;
        }

        public UltimateResult<List<Assignment>> UpdateAssignment(Assignment parameter)
        {
            UltimateResult<List<Assignment>> result = new UltimateResult<List<Assignment>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[assignment_UpdateAssignment]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@id", parameter.Id);
                        sqlCommand.Parameters.AddWithValue("@userId", parameter.UserId);
                        sqlCommand.Parameters.AddWithValue("@appointerId", parameter.AppointerId);
                        sqlCommand.Parameters.AddWithValue("@itemType", parameter.ItemType);
                        sqlCommand.Parameters.AddWithValue("@insertDate", parameter.InsertDate);
                        sqlCommand.Parameters.AddWithValue("@recallDate", parameter.RecallDate);

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

            AddLog(parameter.UserId, "Fatura Güncellendi");
            return result;
        }

        public UltimateResult<List<Assignment>> GetAssignmentUser(Assignment parameter)
        {
            List<Assignment> assignments = new List<Assignment>();
            UltimateResult<List<Assignment>> result = new UltimateResult<List<Assignment>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[assignment_GetAssignmentsUser]";

            List<Accessory> accessories = AccessoryManager.Instance.GetAccessories().Data;
            List<Bill> bills = BillManager.Instance.GetBills().Data;
            List<Component> components = ComponentManager.Instance.GetComponents().Data;
            List<License> licenses = LicenseManager.Instance.GetLicenses().Data;
            List<Toner> toners = TonerManager.Instance.GetToners().Data;
            List<Fixture> fixtures = FixtureManager.Instance.GetFixtures().Data;

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();
                        sqlCommand.Parameters.AddWithValue("@userId", parameter.UserId);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    Assignment assignment = new Assignment();
                                    assignment.Id = Convert.ToInt32(read["id"]);
                                    assignment.UserId = Convert.ToInt32(read["userId"]);
                                    assignment.InsertDate = Convert.ToDateTime(read["insertDate"]);
                                    assignment.AppointerId = Convert.ToInt32(read["appointerId"]);
                                    assignment.ItemType = (ItemType)Convert.ToInt32(read["itemType"]);
                                    assignment.ItemId = Convert.ToInt32(read["itemId"]);
                                    assignment.RecallDate = Convert.ToDateTime(read["recallDate"]);
                                    assignment.Piece = Convert.ToInt32(read["piece"]);
                                    assignment.IsRecall = Convert.ToBoolean(read["isRecall"]);
                                    assignment.Report = Convert.ToBoolean(read["report"]);

                                    if (assignment.ItemType == ItemType.Accessory)
                                    {
                                        assignment.Accessories = (accessories.Find(x => x.Id == assignment.ItemId));
                                    }
                                    else if (assignment.ItemType == ItemType.Bill)
                                    {
                                        assignment.Bills = (bills.Find(x => x.Id == assignment.ItemId));
                                    }
                                    else if (assignment.ItemType == ItemType.Companent)
                                    {
                                        assignment.Components = (components.Find(x => x.Id == assignment.ItemId));
                                    }
                                    else if (assignment.ItemType == ItemType.Fixture)
                                    {
                                        assignment.Fixtures = (fixtures.Find(x => x.Id == assignment.ItemId));
                                    }
                                    else if (assignment.ItemType == ItemType.Licence)
                                    {
                                        assignment.Licences = (licenses.Find(x => x.Id == assignment.ItemId));
                                    }
                                    else if (assignment.ItemType == ItemType.Toner)
                                    {
                                        assignment.Toners = (toners.Find(x => x.Id == assignment.ItemId));
                                    }

                                    assignments.Add(assignment);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = assignments;
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

        public UltimateResult<List<Assignment>> GetAssignmentsByCompany(Assignment parameter)
        {
            List<Assignment> assignments = new List<Assignment>();
            UltimateResult<List<Assignment>> result = new UltimateResult<List<Assignment>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[assignment_GetAssignmentsByCompany]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    List<Accessory> accessories = AccessoryManager.Instance.GetAccessories().Data;
                    List<Bill> bills = BillManager.Instance.GetBills().Data;
                    List<Component> components = ComponentManager.Instance.GetComponents().Data;
                    List<License> licenses = LicenseManager.Instance.GetLicenses().Data;
                    List<Toner> toners = TonerManager.Instance.GetToners().Data;
                    List<Fixture> fixtures = FixtureManager.Instance.GetFixtures().Data;

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
                                    Assignment assignment = new Assignment();
                                    assignment.Id = Convert.ToInt32(read["id"]);
                                    assignment.UserId = Convert.ToInt32(read["userId"]);
                                    assignment.InsertDate = Convert.ToDateTime(read["insertDate"]);
                                    assignment.AppointerId = Convert.ToInt32(read["appointerId"]);
                                    assignment.ItemType = (ItemType)Convert.ToInt32(read["itemType"]);
                                    assignment.ItemId = Convert.ToInt32(read["itemId"]);
                                    assignment.RecallDate = Convert.ToDateTime(read["recallDate"]);
                                    assignment.Piece = Convert.ToInt32(read["piece"]);
                                    assignment.IsRecall = Convert.ToBoolean(read["isRecall"]);
                                    assignment.Report = Convert.ToBoolean(read["report"]);

                                    if (assignment.ItemType == ItemType.Accessory)
                                    {
                                        assignment.Accessories = (accessories.Find(x => x.Id == assignment.ItemId));
                                    }
                                    else if (assignment.ItemType == ItemType.Bill)
                                    {
                                        assignment.Bills = (bills.Find(x => x.Id == assignment.ItemId));
                                    }
                                    else if (assignment.ItemType == ItemType.Companent)
                                    {
                                        assignment.Components = (components.Find(x => x.Id == assignment.ItemId));
                                    }
                                    else if (assignment.ItemType == ItemType.Fixture)
                                    {
                                        assignment.Fixtures = (fixtures.Find(x => x.Id == assignment.ItemId));
                                    }
                                    else if (assignment.ItemType == ItemType.Licence)
                                    {
                                        assignment.Licences = (licenses.Find(x => x.Id == assignment.ItemId));
                                    }
                                    else if (assignment.ItemType == ItemType.Toner)
                                    {
                                        assignment.Toners = (toners.Find(x => x.Id == assignment.ItemId));
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    assignments.Add(assignment);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = assignments;
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
