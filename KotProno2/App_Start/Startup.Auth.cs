using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

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
                LoginPath = new PathString("/Account/Login")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            app.UseTwitterAuthentication(
               consumerKey: "ABzwJl3lBu4aX6FbVMcQOK4ox",
               //TODO: change and ignore file before push to public github
               consumerSecret: "LQTe46uSBdpXTkssc4SMyS22m0MNYd3NJa6woFvEk98rLYigwc");

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