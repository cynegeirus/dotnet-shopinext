using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using ShopinextDotNet.Utilities.Helpers;
using ShopinextDotNet.Utilities.Result;

namespace ShopinextDotNet.Utilities.Middlewares;

public abstract class ExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
    {
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        FileLogHelper.WriteErrorLogAsync(new ErrorLog
        {
            Logged = DateTime.Now,
            Title = MethodBase.GetCurrentMethod()?.Name,
            Exception = ex
        });

        return httpContext.Response.WriteAsync(new ErrorMessage
        {
            StatusCode = httpContext.Response.StatusCode,
            Message = "Internal Server Error"
        }.ToString());
    }
}