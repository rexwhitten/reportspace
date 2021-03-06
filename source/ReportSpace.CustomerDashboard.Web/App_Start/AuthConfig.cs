﻿using WebMatrix.WebData;

namespace ReportSpace.CustomerDashboard.Web
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection(
                    "DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);

                if (WebSecurity.UserExists("root"))
                {
                }
                else
                {
                    WebSecurity.CreateUserAndAccount("root", "!QAZxsw2");

                }
            }
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

            //OAuthWebSecurity.RegisterFacebookClient(
            //    appId: "",
            //    appSecret: "");

            //OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
