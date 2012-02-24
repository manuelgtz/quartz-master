using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Globalization;

namespace QuartzMaster.Base.ActionFilters
{
    public class Localize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            string acceptLanguage = string.Empty;

            if (filterContext.RouteData.Values.ContainsKey("lang"))
            {
                string langStr = filterContext.RouteData.Values["lang"].ToString();
                if (CultureInfo.GetCultures(CultureTypes.AllCultures).
                    Any(c => c.Name.Equals(langStr, StringComparison.OrdinalIgnoreCase)))
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(langStr);
                    System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(langStr);
                }
            }

        }
    }
}
