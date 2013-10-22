namespace ReportSpace.CustomerDashboard.Web.Helpers
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;

    public static class AjaxHelperExtensions
    {
        public static IHtmlString ImageActionLink(this AjaxHelper helper, string content, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            var link = helper.ActionLink("[replaceme]", actionName, routeValues, ajaxOptions, htmlAttributes).ToHtmlString();
            return MvcHtmlString.Create(link.Replace("[replaceme]", content));
        }
    }
}