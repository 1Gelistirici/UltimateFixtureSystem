using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class CompanyCallManager
    {
        private static readonly object Lock = new object();
        private static volatile CompanyManager companyManager;
        private static volatile CompanyCallManager _instance;
        public static CompanyCallManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new CompanyCallManager();
                            companyManager = new CompanyManager();
                        }
                    }
                }
                return _instance;
            }
        }


        public UltimateResult<List<Company>> GetCompanies()
        {
            return companyManager.GetCompanies();
        }

        public UltimateResult<List<Company>> GetCompanyGroup(ReferansParameter parameter)
        {
            return companyManager.GetCompanyGroup(parameter);
        }

        public UltimateResult<Company> GetCompany(ReferansParameter parameter)
        {
            return companyManager.GetCompany(parameter);
        }

        public UltimateSetResult DeleteCompany(ReferansParameter parameter)
        {
            return companyManager.DeleteCompany(parameter);
        }

        public UltimateSetResult AddCompany(Company parameter)
        {
            return companyManager.AddCompany(parameter);
        }

        public UltimateSetResult AddCompanyV1(CompanyUser parameter)
        {
            UltimateSetResult result = companyManager.AddCompanyV1(parameter);

            if (result.IsSuccess)
            {
                UserCallManager userCallManager = new UserCallManager();
                parameter.User.CompanyId = result.ReturnId;
                parameter.User.Title = "";
                parameter.User.ImageName = "";
                parameter.User.ImageUrl = "";

                UltimateSetResult userResult = userCallManager.AddUser(parameter.User);
                if (userResult.IsSuccess)
                {
                    UltimateResult<List<Menu>> menuList = MenuCallManager.Instance.GetMenus();
                    UserRole userRole = new UserRole();
                    userRole.UserRefId = userResult.ReturnId;

                    foreach (Menu item in menuList.Data)
                    {
                        userRole.MenuRefId = item.Id;
                        UserRoleCallManager.Instance.AddRole(userRole);
                    }
                }
            }

            return result;
        }

        public UltimateSetResult UpdateCompany(Company parameter)
        {
            return companyManager.UpdateCompany(parameter);
        }

    }
}
