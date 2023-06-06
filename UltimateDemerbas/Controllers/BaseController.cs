using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using UltimateAPI.Entities;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    public abstract class BaseController : Controller
    {
        public int WorkingUser { get { return HttpContext.Session.GetInt32("Id") == null ? 0 : (int)HttpContext.Session.GetInt32("Id"); } }
        public int WorkingCompany { get { return HttpContext.Session.GetInt32("CompanyId") == null ? 0 : (int)HttpContext.Session.GetInt32("CompanyId"); } }



        protected abstract int PageNumber { get; set; }
        public void CheckSecurity()
        {
            if (WorkingUser > 0 && PageNumber > 0)
            {
                bool isAuthorized = UserRoleAuthentication.Instance.CheckMenuUserRole(WorkingUser, PageNumber);

                if (!isAuthorized)
                {
                    Response.Redirect("/Error");
                }
            }
            else if (WorkingUser <= 0)
            {
                string companyId = Request.Cookies["companyId"];
                string userId = Request.Cookies["userId"];

                if (userId != "" && userId != null && companyId != "" && companyId != null)
                {
                    ReferansParameter referansParameter = new ReferansParameter();
                    referansParameter.Id = Convert.ToInt32(userId);
                    referansParameter.CompanyId = Convert.ToInt32(companyId);
                    SetSession(referansParameter);

                    return;
                }


                Response.Redirect("/User/Login");
                return;
            }
        }

        public void GetActiveUser()
        {
            HttpContext.Session.GetInt32("Id");
            HttpContext.Session.GetInt32("CompanyId");
        }

        public void SetSession(ReferansParameter parameter)
        {
            HttpContext.Session.SetInt32("Id", parameter.Id);
            HttpContext.Session.SetInt32("CompanyId", parameter.CompanyId);
            //HttpContext.Session.SetInt32("RememberMe", Convert.ToInt16(parameter.RememberMe));
        }

        public void RemoveActiveUser()
        {
            HttpContext.Session.Remove("Id");
            HttpContext.Session.Remove("CompanyId");
            HttpContext.Session.Remove("RememberMe");
        }

    }
}
