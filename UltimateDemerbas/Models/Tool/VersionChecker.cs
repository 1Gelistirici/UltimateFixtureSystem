using System;
using System.Web;

namespace UltimateDemerbas.Models.Tool
{
    public static class VersionChecker
    {
        public static string GetDateVersionJs()
        {
            return $"?{GetDateVersion()}";
        }
        public static string GetDateVersion()
        {
            //return "v=" + (HttpContext.Current.Application["JsKey"] ?? $"{DateTime.Now:yyyyMMddHHmmss}").ToString();
            return "";
        }
    }
}