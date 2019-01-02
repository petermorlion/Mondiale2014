using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using Autofac.Integration.WebApi;
using Serilog;

namespace KotProno2
{
    public class WebApiExceptionFilter : IAutofacExceptionFilter
    {
        private readonly ILogger _logger;

        public WebApiExceptionFilter(ILogger logger)
        {
            _logger = logger;
        }

        public Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            _logger.Error(actionExecutedContext.Exception, "An unhandled exception occurred.");
            return Task.FromResult(0);
        }
    }
}