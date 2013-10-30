using System.Web.Mvc;

namespace ReportSpace.CustomerDashboard.Web.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;

    using ReportSpace.CustomerDashboard.Core;
    using ReportSpace.CustomerDashboard.Core.Models;
    using ReportSpace.CustomerDashboard.Web.ViewModels;

    using AutoMapper;

    using WebMatrix.WebData;
    using System;
    using ReportSpace.CustomerDashboard.Web.Controllers.Core;

    [Authorize(Roles = "Administrator")]
    public class UserController : Controller
    {
        #region [ Fields ] 
        private IUserContext _userContext;
        private ReportingService2010.ReportingService2010 m_client = new ReportingService2010.ReportingService2010();
        private SSRSContext m_context = new SSRSContext();
        #endregion 

        #region [ Constructors ]
        public UserController(IUserContext context)
        {
            _userContext = context;
        }
        #endregion

        #region [ Controller Methods ]
        public ActionResult Index()
        {
            List<UserProfile> userProfiles = new List<UserProfile>();

            var client_folders = this.m_context.GetCatalog("/Client Reports/root");
            
            foreach (var client_folder in client_folders.Items)
            {
                string client_name = client_folder.Name.Replace(" ", "").ToLower();

                if (!WebSecurity.UserExists(client_name))
                {
                    WebSecurity.CreateUserAndAccount(client_name, "client_!1@");
                }
            }

            return View();
        }

        #endregion 

        #region [ Local Methods ] 
        #endregion
    }
}
