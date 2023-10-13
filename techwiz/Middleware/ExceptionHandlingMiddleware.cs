using TechWiz.Errors;
using TechWiz.Utilities;

namespace TechWiz.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch
            {
                await ErrorHelper.SendErrorResponseAsJson(context, 500, new InternalServerError());
            }
        }
    }
}