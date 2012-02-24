using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Compilation;
using System.Globalization;

namespace QuartzMaster.Base.Helpers
{
    public static class LocalizationHelpers
    {
        public static IHtmlString MetaAcceptLanguage<T>(this HtmlHelper<T> html)
        {
            string acceptLanguage = string.Empty;
            
            acceptLanguage = HttpUtility.HtmlAttributeEncode(System.Threading.Thread.CurrentThread.CurrentUICulture.ToString());
            return new HtmlString(String.Format("<meta name='accept-language' content='{0}'>", acceptLanguage));
        }

        public static IHtmlString MetaAcceptLanguage(this HtmlHelper<dynamic> html)
        {
            string acceptLanguage = string.Empty;

            acceptLanguage = HttpUtility.HtmlAttributeEncode(System.Threading.Thread.CurrentThread.CurrentUICulture.ToString());
            return new HtmlString(String.Format("<meta name='accept-language' content='{0}'>", acceptLanguage));            
        }

        #region Helpers For Fetching Resource Strings
        /*
         * Huge credit to Tyson Swing's blog post on this! 
         * (http://publicityson.blogspot.com/2010/11/aspnet-mvc-razor-view-engine-and.html)
         * without his blog post I would probably look for those functions for some time...
        */

        public static object GlobalResource(this HtmlHelper htmlHelper, string classKey, string resourceKey)
        {
            return htmlHelper.ViewContext.HttpContext.GetGlobalResourceObject(classKey, resourceKey);
        }

        public static T GlobalResource<T>(this HtmlHelper htmlHelper, string classKey, string resourceKey)
        {
            return (T)htmlHelper.ViewContext.HttpContext.GetGlobalResourceObject(classKey, resourceKey);
        }

        public static object GlobalResource(this HtmlHelper htmlHelper, string classKey, string resourceKey, CultureInfo culture)
        {
            return htmlHelper.ViewContext.HttpContext.GetGlobalResourceObject(classKey, resourceKey, culture);
        }

        public static T GlobalResource<T>(this HtmlHelper htmlHelper, string classKey, string resourceKey, CultureInfo culture)
        {
            return (T)htmlHelper.ViewContext.HttpContext.GetGlobalResourceObject(classKey, resourceKey, culture);
        }

        public static object LocalResource(this HtmlHelper htmlHelper, string classKey, string resourceKey)
        {
            return htmlHelper.ViewContext.HttpContext.GetLocalResourceObject(classKey, resourceKey);
        }

        public static T LocalResource<T>(this HtmlHelper htmlHelper, string classKey, string resourceKey)
        {
            return (T)htmlHelper.ViewContext.HttpContext.GetLocalResourceObject(classKey, resourceKey);
        }

        public static object LocalResource(this HtmlHelper htmlHelper, string classKey, string resourceKey, CultureInfo culture)
        {
            return htmlHelper.ViewContext.HttpContext.GetLocalResourceObject(classKey, resourceKey, culture);
        }

        public static T LocalResource<T>(this HtmlHelper htmlHelper, string classKey, string resourceKey, CultureInfo culture)
        {
            return (T)htmlHelper.ViewContext.HttpContext.GetLocalResourceObject(classKey, resourceKey, culture);
        }

        #endregion

    }
}
