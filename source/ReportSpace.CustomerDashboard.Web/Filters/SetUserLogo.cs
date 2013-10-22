namespace ReportSpace.CustomerDashboard.Web.Filters
{
    using System.Linq;
    using System.Web.Mvc;

    using ReportSpace.CustomerDashboard.Core;
    using WebMatrix.WebData;

    public class SetUserLogo : IActionFilter
    {
        public IUserContext UserContext { get; set; }

        public SetUserLogo(IUserContext userContext)
        {
            UserContext = userContext;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
           
        }
    }
}