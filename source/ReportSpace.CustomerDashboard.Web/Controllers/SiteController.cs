using ReportSpace.CustomerDashboard.Web.Models;
using Microsoft.Web.WebPages.OAuth;
﻿using System.Web.Mvc;

using WebMatrix.WebData;

namespace ReportSpace.CustomerDashboard.Web.Controllers
{
    [Authorize]
    public class SiteController : Controller
    {
       #region [ Login ] 
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            return View("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            string role_redirect_url = "";

            // Redirect to the View based on Role 
            //  /Role/Dashbaord
           #region [ Initial Admin Setup ] 
            if (model.UserName == "SetupAdmin")
            {
                if (!WebSecurity.UserExists("admin"))
                {
                    return RedirectToLocal("/Admin/SetupAdmin");
                }
                else
                {
                    ModelState.AddModelError("", "Admin user has already been setup.");
                    return View(model);
                }
            }
            #endregion


            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                // Get the Roles
              
                return RedirectToLocal(role_redirect_url);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }
        #endregion

        #region [ Dashboard ] 
        public ActionResult Dashboard()
        {
            return View();
        }
        #endregion

        #region [ Menu ] 

        #endregion

        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Categories", "Report");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }

        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
            }
        }

        #endregion
    }
}