using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace QuartzMaster.Base.Helpers
{
    public static class GenericExtenders
    {
        public static string ToAbsoluteUrl(this string relativeUrl)
        {
            if (HttpContext.Current == null || string.IsNullOrEmpty(relativeUrl))
                return relativeUrl;

            return new Uri(HttpContext.Current.Request.Url, relativeUrl).ToString();
        }
    }
}
