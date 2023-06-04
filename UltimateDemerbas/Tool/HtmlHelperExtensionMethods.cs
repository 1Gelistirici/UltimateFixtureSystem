using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using MultiLanguage.Utilities;

namespace MultiLanguage.ExtensionMethods
{
    public static class HtmlHelperExtensionMethods
    {
        public static string Translate(this IHtmlHelper helper, string key)
        {
            key = key.Replace(" ", "");
            key = key.Substring(0, 1).ToLower() + key.Substring(1);

            IServiceProvider services = helper.ViewContext.HttpContext.RequestServices;
            SharedViewLocalizer localizer = services.GetRequiredService<SharedViewLocalizer>();
            string result = localizer[key];
            return result;
        }

        public static List<SelectListItem> GetCultures(this IHtmlHelper helper)
        {
            var defaultCultures = new List<CultureInfo>()
            {
                new CultureInfo("tr-TR"),
                new CultureInfo("en-US"),
            };

            CultureInfo[] cinfo = CultureInfo.GetCultures(CultureTypes.AllCultures);
            var cultureItems = cinfo.Where(x => defaultCultures.Contains(x))
                .Select(c => new SelectListItem { Value = c.Name, Text = c.DisplayName })
                .ToList();

            return cultureItems;
        }

    }
}
