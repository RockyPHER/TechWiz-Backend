using System.Text.Json;
using TechWiz.Errors;

namespace TechWiz.Utilities
{
    public static class ErrorHelper
    {
        public static async Task SendErrorResponseAsJson(HttpContext context, int statusCode, BaseError error)
        {
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            var json = JsonSerializer.Serialize(error);
            await context.Response.WriteAsync(json);
        }
    }
}