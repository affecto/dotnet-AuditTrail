using System;
using System.Web.Http.Filters;
using Affecto.Authentication.Claims;
using Affecto.WebApi.Toolkit;

namespace Affecto.AuditTrail.WebApi
{
    public class WebApiRequestExceptionFilter : RequestExceptionFilter
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            Exception exception = actionExecutedContext.Exception;
            if (exception is InsufficientPermissionsException)
            {
                InsufficientPermissionsException permissionException = (InsufficientPermissionsException)exception;
                actionExecutedContext.Response = CreateStringContentResponse(permissionException.Permission, "User has insufficient permissions.");
            }
            else
            {
                base.OnException(actionExecutedContext);
            }
        }
    }
}