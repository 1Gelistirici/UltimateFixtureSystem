using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Controllers
{
    public abstract class BaseController : Controller
    {
        public int WorkingUser { get { return HttpContext.Session.GetInt32("Id") == null ? 0 : (int)HttpContext.Session.GetInt32("Id"); } }
        public int WorkingCompany { get { return HttpContext.Session.GetInt32("CompanyId") == null ? 0 : (int)HttpContext.Session.GetInt32("CompanyId"); } }



        protected abstract int PageNumber { get; set; }
        public void CheckSecurity()
        {
            if (PageNumber > 0)
            {
                bool result = true;/* MenuItemsManager.Instance.GetMenuCompanyUserCheck(new ReferanceParameter() { RefId = WorkingUser }, PageNumber);*/
                if (!result)
                {
                    Response.Redirect("/Error");
                }
            }
        }

        public void GetActiveUser()
        {
            var a = HttpContext.Session.GetInt32("Id");
            var b = HttpContext.Session.GetInt32("CompanyId");
        }

        public void SetSession(ReferansParameter parameter)
        {
            HttpContext.Session.SetInt32("Id", parameter.Id);
            HttpContext.Session.SetInt32("CompanyId", parameter.CompanyId);
        }

        public void RemoveActiveUser()
        {
            HttpContext.Session.Remove("Id");
            HttpContext.Session.Remove("CompanyId");
        }

    }
}
