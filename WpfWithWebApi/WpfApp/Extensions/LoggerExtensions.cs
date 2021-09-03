using System.Net.Http;

//Use Microsofts namespace for logging to avoid having to add your own usings everywhere logextension is going to be used
namespace Microsoft.Extensions.Logging
{
    public static class LoggerExtensions
    {
        public static void LogHttpRequest<T>(this ILogger<T> logger, LogLevel level, HttpRequestMessage request, string message, params object[] args)
            where T : class =>

            //TODO Add information from the request
            logger.Log(level, message, args);

        public static void LogHttpResponse<T>(this ILogger<T> logger, LogLevel level, HttpResponseMessage response, string message, params object[] args)
            where T : class =>

            //TODO Add information from the response
            logger.Log(level, message, args);
    }
}