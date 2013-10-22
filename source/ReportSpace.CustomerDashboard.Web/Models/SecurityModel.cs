using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGA.CustomerDashboard.Web.Models
{
    public class SecurityModel
    {
        internal static string GetUserRedirect(LoginModel model)
        {
            WebMatrix.WebData.SimpleRoleProvider roleProvider = new WebMatrix.WebData.SimpleRoleProvider();
            string redirect_url = "";

            string[] roles = roleProvider.GetRolesForUser(model.UserName);

            foreach (string role in roles)
            {
                switch (role.ToLower())
                {
                    case "administrator":
                        redirect_url = "Admin/Dashboard";
                        break;
                    case "customer" :
                        redirect_url = "Site/Dashboard";
                        break;
                    default :
                        redirect_url = "Site/Dashboard";
                        break;
                }
            }


            return redirect_url;
        }
    }
}