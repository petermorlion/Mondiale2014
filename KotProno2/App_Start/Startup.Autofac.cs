using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using KotProno2.EntityFramework;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Owin;
using Serilog;

namespace KotProno2
{
    public partial class Startup
    {
        private static TelemetryClient _telemetryClient;

        public static TelemetryClient TelemetryClient => _telemetryClient ?? (_telemetryClient = new TelemetryClient(new TelemetryConfiguration("")
        {
            ConnectionString = ConfigurationManager.AppSettings["APPINSIGHTS_CONNECTIONSTRING"]
        }));
        
        public void ConfigureAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<MatchesDbContext>().InstancePerRequest();

            var log = new LoggerConfiguration()
//#if DEBUG
                .WriteTo.Console()
//#else 
//                .WriteTo.ApplicationInsightsEvents(TelemetryClient)
//#endif
                .CreateLogger();
            builder.RegisterInstance(log).As<ILogger>();

            builder.RegisterType<WebApiExceptionFilter>().AsWebApiExceptionFilterFor<ApiController>().InstancePerRequest();

            builder.RegisterFilterProvider();

            var config = GlobalConfiguration.Configuration;
            builder.RegisterWebApiFilterProvider(config);
            
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }
    }
}