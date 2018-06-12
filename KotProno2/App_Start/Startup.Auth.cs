using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Configuration;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Twitter;

namespace KotProno2
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/#/login")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //if (ConfigurationManager.AppSettings["MicrosoftClientId"] != null
            //    && ConfigurationManager.AppSettings["MicrosoftClientSecret"] != null)
            //{
            //    app.UseMicrosoftAccountAuthentication(
            //        clientId: ConfigurationManager.AppSettings["MicrosoftClientId"],
            //        clientSecret: ConfigurationManager.AppSettings["MicrosoftClientSecret"]);
            //}

            //if (ConfigurationManager.AppSettings["TwitterKey"] != null
            //    && ConfigurationManager.AppSettings["TwitterSecret"] != null)
            //{
            //    app.UseTwitterAuthentication(new TwitterAuthenticationOptions
            //    {
            //        ConsumerKey = ConfigurationManager.AppSettings["TwitterKey"],
            //        ConsumerSecret = ConfigurationManager.AppSettings["TwitterSecret"],
            //        BackchannelCertificateValidator = new CertificateSubjectKeyIdentifierValidator(new[]
            //        {
            //            "A5EF0B11CEC04103A34A659048B21CE0572D7D47", // VeriSign Class 3 Secure Server CA - G2
            //            "0D445C165344C1827E1D20AB25F40163D8BE79A5", // VeriSign Class 3 Secure Server CA - G3
            //            "7FD365A7C2DDECBBF03009F34339FA02AF333133", // VeriSign Class 3 Public Primary Certification Authority - G5
            //            "39A55D933676616E73A761DFA16A7E59CDE66FAD", // Symantec Class 3 Secure Server CA - G4
            //            "5168FF90AF0207753CCCD9656462A212B859723B", //DigiCert SHA2 High Assurance Server C‎A 
            //            "B13EC36903F8BF4701D498261A0802EF63642BC3" //DigiCert High Assurance EV Root CA
            //        })
            //    });
            //}

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication();

            // Return 401 instead of 302 when not authorized and doing a WebAPI call (OWIN turns it into a 302)
            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //    {
            //        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            //        LoginPath = new PathString("/Account/Login"),
            //        Provider = new CookieAuthenticationProvider
            //        {
            //            OnApplyRedirect = ctx =>
            //                {
            //                    if (!IsAjaxRequest(ctx.Request))
            //                    {
            //                        ctx.Response.Redirect(ctx.RedirectUri);
            //                    }
            //                }
            //        }
            //    });
        }

        //private bool IsAjaxRequest(IOwinRequest owinRequest)
        //{
        //    var query = owinRequest.Query;
        //    if ((query != null) && (query["X-Requested-With"] == "XMLHttpRequest"))
        //    {
        //        return true;
        //    }

        //    var headers = owinRequest.Headers;
        //    return ((headers != null) && headers["X-Requested-With"] == "XMLHttpRequest");
        //}
    }
}