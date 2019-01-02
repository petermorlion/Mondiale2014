using System.Web.Mvc;
using Serilog;

namespace KotProno2
{
    public class MvcExceptionFilter : IExceptionFilter
    {
        public ILogger Logger { get; set; }

        public void OnException(ExceptionContext filterContext)
        {
            Logger.Error(filterContext.Exception, "An unhandled exception occurred.");
        }
    }
}