using Microsoft.AspNetCore.Mvc;
using PackIT.SharedAbstractions.Exceptions;

namespace PackIT.API.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(PackItException e)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(e.Message);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(e.Message);
            }
        }
    }
}
