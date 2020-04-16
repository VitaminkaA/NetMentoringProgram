using System;
using System.Web.Mvc;
using NLog;

namespace MvcMusicStore.Filters
{
    public class CustomExceptionFilterAttribute : IExceptionFilter
    {
        private readonly ILogger _logger;

        public CustomExceptionFilterAttribute()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }
        public void OnException(ExceptionContext exceptionContext)
        {
            exceptionContext.ExceptionHandled = true;
            _logger.Error(exceptionContext.Exception.Message);
            exceptionContext.Result = new RedirectResult("/Home/Error");
        }
    }
}