using System;
using System.Web.Mvc;
using NLog;

namespace BTC.Shared.Mvc
{
    [AttributeUsage(AttributeTargets.All)]
    public class HandleErrorAttributeExceptionFilter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            LogManager.GetCurrentClassLogger().Error(filterContext.Exception);
            base.OnException(filterContext);
        }
    }
}