namespace ReportSpace.CustomerDashboard.Web.Helpers
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    public static class HtmlHelperExtensions
    {
        public static IHtmlString ActionLinkWithContent(this HtmlHelper helper, string content, string actionName, string controllerName, object routeValues, object htmlAttributes)
        {
            var link = helper.ActionLink("[replaceme]", actionName, controllerName, routeValues, htmlAttributes).ToHtmlString();
            return MvcHtmlString.Create(link.Replace("[replaceme]", content));
        }
    }
}