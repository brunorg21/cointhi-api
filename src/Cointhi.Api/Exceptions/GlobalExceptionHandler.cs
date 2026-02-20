using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Cointhi.Api.Exceptions
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IProblemDetailsService problemDetailsService) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            logger.LogError(exception, "An unhandled exception occurred.");

            httpContext.Response.StatusCode = exception switch
            {
                ApplicationException => StatusCodes.Status400BadRequest,
                ValidationException => StatusCodes.Status400BadRequest,
                UserAlreadyExistsException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                InvalidCredentialsException => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };

            if(exception is ValidationException validationException)
            {
                return await problemDetailsService.TryWriteAsync(
                    new ProblemDetailsContext
                    {
                        HttpContext = httpContext,
                        Exception = exception,
                        ProblemDetails = new ValidationProblemDetails(
                            validationException.Errors
                                .GroupBy(e => e.PropertyName)
                                .ToDictionary(
                                    g => g.Key,
                                    g => g.Select(e => e.ErrorMessage).ToArray()
                                )
                        )
                        {
                            Type = exception.GetType().Name,
                            Title = "One or more validation errors occurred.",
                            Detail = "See the errors property for details."
                        }
                    }
                );
            }


            return await problemDetailsService.TryWriteAsync(
                    new ProblemDetailsContext
                    {
                        HttpContext = httpContext,
                        Exception = exception,
                        ProblemDetails = new ProblemDetails
                        {
                            Type = exception.GetType().Name,
                            Detail = exception.Message,
                            Title = "An error occurred while processing your request.",
                        }
                    }
                );
        }
    }
}
