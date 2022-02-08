using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace UltimateDemerbas.Controllers
{
    public abstract class BaseController : Controller
    {
        public int WorkingUser { get { return GetActiveUserId(); } }



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

        public int GetActiveUserId()
        {
            return (int)HttpContext.Session.GetInt32("Test");
        }

        public void SetActiveUserId()
        {
            HttpContext.Session.SetString("Test", "Ben Rules!");
        } 
        
        public void RemoveActiveUserId()
        {
            HttpContext.Session.Remove("Test");
        }



    }
}
