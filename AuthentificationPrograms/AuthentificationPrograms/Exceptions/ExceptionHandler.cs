using AuthentificationPrograms.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuthentificationService
{
    public class ExceptionHandler : ActionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is CustomException)
            {
                context.Result = new BadRequestObjectResult(context.Exception.Message);
            }
            else
            {
                // Во время разработки возвращаем полную информацию об ошибке
                context.Result = new BadRequestObjectResult(new
                {
                    Error = context.Exception.Message,
                    Exception = context.Exception.GetType().Name,
                    StackTrace = context.Exception.StackTrace
                });
            }

            context.ExceptionHandled = true;
        }
    }
}