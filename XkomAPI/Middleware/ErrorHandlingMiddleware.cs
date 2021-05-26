using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using XkomAPI.Exceptions;

namespace XkomAPI.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(NotFoundException e)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Not found: " + e.Message);
            }
            catch(EmailIsTakenException e)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Email is taken: " + e.Message);
            }
            catch(MeetingIsFullException e)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Meeting is full!");
            }
            catch(Exception e)
            {
                context.Response.StatusCode = 500;

                await context.Response.WriteAsync("Something went wrong! " + e.Message);
            }
        }
    }
}