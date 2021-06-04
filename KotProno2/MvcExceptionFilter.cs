using System.Web.Mvc;
using Serilog;

namespace KotProno2
{
    public class MvcExceptionFilter : IExceptionFilter
    {
        public ILogger Logger { get; set; }

        public void OnException(ExceptionContext filterContext)
        {
            if (Logger != null && filterContext != null && filterContext.Exception != null)
            {
                Logger.Error(filterContext.Exception, "An unhandled exception occurred.");
            }
        }
    }
}