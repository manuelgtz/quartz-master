using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace QuartzMaster.Base.Helpers
{
    public static class MenuExtenders
    {
        public static MvcHtmlString MenuItem(this HtmlHelper html, string actionName,
            string controllerName,string unselectedCss,string selectedCss, 
            string menuCaption,string tagName = "div",IDictionary<string,object> htmlAttributes = null, 
            string permissionName = "",bool isVisible = true,object routeValues = null)
        {
            if (isVisible)
            {
                bool canUserSeeItem = false;
                if (!String.IsNullOrWhiteSpace(permissionName))
                {
                    //TODO : check here visibility of menu item by permission check
                    canUserSeeItem = false;
                }
                else
                {
                    canUserSeeItem = true;
                }

                if (canUserSeeItem == true)
                {
                    string selectionString = String.Empty;
                    string selectionCssClass = String.Empty;
                    if (html.ViewContext.Controller.ValueProvider.GetValue("controller").RawValue.ToString().Equals(controllerName, StringComparison.OrdinalIgnoreCase) && html.ViewContext.Controller.ValueProvider.GetValue("controller").RawValue.ToString().Equals(controllerName, StringComparison.OrdinalIgnoreCase))
                    {
                        selectionString = "true";
                        selectionCssClass = selectedCss;
                    }
                    else
                    {
                        selectionCssClass = unselectedCss;
                        selectionString = "false";
                    }

                    string itemControl = String.Empty;
                    if (routeValues == null)
                    {
                        itemControl = String.Format(@"
                                                    <{3} class='{2} MenuItem' data-isSelected='{1}'>
                                                        {0}
                                                    </{3}>
                                                   ", html.ActionLink(menuCaption, actionName, controllerName),
                                                            selectionString, selectionCssClass, tagName);
                    }
                    else
                    {
                        itemControl = String.Format(@"
                                                    <{3} class='{2} MenuItem' data-isSelected='{1}'>
                                                        {0}
                                                    </{3}>
                                                   ", html.ActionLink(menuCaption, actionName, controllerName,routeValues,null),
                                                            selectionString, selectionCssClass, tagName);
                    }

                    return MvcHtmlString.Create(itemControl);
                }
            }
            return MvcHtmlString.Create("");
        }

    }
}
