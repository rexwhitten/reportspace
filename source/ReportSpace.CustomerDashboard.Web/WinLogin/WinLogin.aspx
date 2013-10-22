<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%
    var loggedInUsername = Request.ServerVariables["LOGON_USER"];
    
    var membershipUser = Membership.Provider.GetUser(loggedInUsername, false);
    if (membershipUser != null)
    {
        FormsAuthentication.RedirectFromLoginPage(loggedInUsername, true);
    }
    else
    {
        Response.RedirectToRoute(new
                                     {
                                         controller="Account", 
                                         action="Login", 
                                         returnUrl=Request.QueryString["ReturnUrl"]
                                     });
    }
%>