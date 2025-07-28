using System.Reflection;
using Microsoft.AspNetCore.Http;
using ShopinextDotNet.Utilities.Extensions;
using ShopinextDotNet.Utilities.Helpers;
using ShopinextDotNet.Utilities.Result;

namespace ShopinextDotNet.Utilities.Middlewares;

public abstract class TransactionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        TransactionLog? log = new()
        {
            Logged = DateTime.Now,
            ConnectionId = context.Connection.Id,
            RemoteIpAddress = context.GetRemoteIpAddress()?.ToString(),
            RemotePort = context.Connection.RemotePort.ToString(),
            LocalIpAddress = context.Connection.LocalIpAddress.ToString(),
            LocalPort = context.Connection.LocalPort.ToString(),
            Path = context.Request.Path,
            Method = context.Request.Method,
            QueryString = context.Request.QueryString.ToString()
        };

        if (context.Request.Method == "POST")
        {
            context.Request.EnableBuffering();
            var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
            context.Request.Body.Position = 0;
            log.Payload = body;
        }

        if (context.Request.Method == "PUT")
        {
            context.Request.EnableBuffering();
            var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
            context.Request.Body.Position = 0;
            log.Payload = body;
        }

        if (context.Request.Method == "DELETE")
        {
            context.Request.EnableBuffering();
            var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
            context.Request.Body.Position = 0;
            log.Payload = body;
        }

        log.Requested = DateTime.Now;

        await using (var originalRequest = context.Response.Body)
        {
            try
            {
                using MemoryStream? memStream = new();
                context.Response.Body = memStream;
                memStream.Position = 0;
                var response = await new StreamReader(memStream).ReadToEndAsync();
                log.Response = response;
                log.ResponseCode = context.Response.StatusCode.ToString();
                log.IsSuccess = context.Response.StatusCode is 200 or 201;
                log.Responded = DateTime.Now;

                if (context?.Request?.Host.HasValue ?? false)
                    if (context.Request.Path.ToString() != "/welcome" && context.Request.Path.ToString() != "/")
                        await FileLogHelper.WriteTransactionLogAsync(log);

                memStream.Position = 0;
                await memStream.CopyToAsync(originalRequest);
            }
            catch (Exception ex)
            {
                await FileLogHelper.WriteErrorLogAsync(new ErrorLog
                {
                    Logged = DateTime.Now,
                    Title = MethodBase.GetCurrentMethod()?.Name,
                    Exception = ex
                });
            }
            finally
            {
                if (context != null)
                    context.Response.Body = originalRequest;
            }
        }

        await next.Invoke(context);
    }
}