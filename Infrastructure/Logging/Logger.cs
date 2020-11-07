using Serilog;
using Serilog.Exceptions;
using Serilog.Formatting.Compact;
using System;

namespace WebApiTemplate.Infrastructure.Logging
{
    public static class Logger
    {
        private static readonly ILogger _logger;

        static Logger()
        {
            _logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Async(a => a.File(
                    formatter: new RenderedCompactJsonFormatter(),
                    path: @"c:/logs/web-api-template/log-.json",
                    rollingInterval: RollingInterval.Day,
                    shared: true))
                .Enrich.WithThreadId()
                .Enrich.WithThreadName()
                .Enrich.WithHttpRequestId()
                .Enrich.WithWebApiRouteData()
                .Enrich.WithWebApiActionName()
                .Enrich.WithExceptionDetails()
                .Enrich.FromLogContext()
                .CreateLogger();

        }
        public static void Debug(string message, params object[] propertyValues)
        {
            _logger.Debug(message, propertyValues);
        }

        public static void Info(string message, params object[] propertyValues)
        {
            _logger.Information(message, propertyValues);
        }

        public static void Warn(string message, params object[] propertyValues)
        {
            _logger.Warning(message, propertyValues);
        }

        public static void Error(Exception ex, string error, params object[] propertyValues)
        {
            _logger.Error(ex, error, propertyValues);
        }

        public static void Error(string error, params object[] propertyValues)
        {
            _logger.Error(error, propertyValues);
        }
    }
}