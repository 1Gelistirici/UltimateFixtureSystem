using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UltimateDemerbas.Controllers
{
    public abstract class BaseController : Controller
    {
        public int WorkingUser { get { return (int)HttpContext.Session.GetInt32("Id"); } }
        public int WorkingCompany { get { return (int)HttpContext.Session.GetInt32("CompanyId"); } }



        //HttpContext.Session.SetInt32(1, 24);  
        //HttpContext.Session.SetString("isUserLogin", "true"); // Yeni bir session oluşturma.

        //HttpContext.Session.GetString("isUserLogin"); // Sessiondan değer getirme.

        //HttpContext.Session.Clear(); // Tüm sessionları temizleme.


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

        public void SetActiveUserId(int id, int companyId)
        {
            HttpContext.Session.SetInt32("Id", id);
            HttpContext.Session.SetInt32("CompanyId", companyId);
        }

        public void RemoveActiveUserId()
        {
            HttpContext.Session.Remove("Id");
            HttpContext.Session.Remove("Company");
        }



    }
}
