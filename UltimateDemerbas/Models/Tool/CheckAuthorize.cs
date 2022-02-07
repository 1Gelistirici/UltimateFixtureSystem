using Microsoft.AspNetCore.Mvc.Filters;
using System;
using UltimateDemerbas.Controllers;

namespace UltimateDemerbas.Models.Tool
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class CheckAuthorize : ActionFilterAttribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            ((BaseController)filterContext.Controller).CheckSecurity();
        }
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {

        }
    }
}