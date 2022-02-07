using Microsoft.AspNetCore.Mvc;
using System;

namespace UltimateDemerbas.Controllers
{
    public abstract class BaseController : Controller
    {
        public int WorkingUser { get { return Convert.ToInt32(Request.Cookies["id"]); } }



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





    }
}
