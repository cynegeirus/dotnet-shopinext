using Microsoft.AspNetCore.Builder;
using ShopinextDotNet.Utilities.Middlewares;

namespace ShopinextDotNet.Utilities.Extensions;

public static class TransactionMiddlewareExtension
{
    public static IApplicationBuilder UseTransactionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TransactionMiddleware>();
    }
}