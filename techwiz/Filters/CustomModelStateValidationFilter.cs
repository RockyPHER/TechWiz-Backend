using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.VisualBasic;
using TechWiz.Errors;

namespace TechWiz.Filters
{
    public class CustomModelStateValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
        
        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(e => e.Value?.Errors.Count > 0)
                    .ToDictionary(e => e.Key, e => e.Value?.Errors.Select(error => error.ErrorMessage));


                var result = new BadRequestObjectResult(new ValidationError
                {
                    Error = "ValidationError",
                    Message = "Erro de validação"
                });

                context.Result = result;
            }
        }
    }
}