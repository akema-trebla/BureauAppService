using Microsoft.Azure.Mobile.Server.Login;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BureauAppServiceService.Providers
{
    public class CustomZumoTokenFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private string _host = string.Format("https://{0}.azurewebsites.net/",
                Environment.ExpandEnvironmentVariables("%WEBSITE_SITE_NAME%")
                .ToLower());

        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            // Get Signing Key and send x-zumo-auth token from claims
            string signingKey = GetSigningKey();
            var tokenInfo = AppServiceLoginHandler.CreateToken(
                    data.Identity.Claims,
                    signingKey,
                    _host,
                    _host,
                    TimeSpan.FromHours(24));

            return tokenInfo.RawData;
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }

        private static string GetSigningKey()
        {
            string key =
                Environment.GetEnvironmentVariable("WEBSITE_AUTH_SIGNING_KEY");

            if (string.IsNullOrWhiteSpace(key))
                key = ConfigurationManager.AppSettings["SigningKey"];

            return key;
        }
    }

}