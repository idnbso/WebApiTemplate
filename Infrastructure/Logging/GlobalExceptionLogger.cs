using System.Web.Http.ExceptionHandling;

namespace WebApiTemplate.Infrastructure.Logging
{
    public class GlobalExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            Logger.Error("Unhandled exception: {exc}", context.Exception);
        }
    }
}