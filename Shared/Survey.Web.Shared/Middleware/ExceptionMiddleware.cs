using Microsoft.AspNetCore.Http;
using Survey.Domain.SharedKernal.Validations;
using Survey.Web.Shared.Models;
using System.Net;

namespace Survey.Web.Shared.Middleware
{
    public class ExceptionMiddleware
    {
        protected readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async virtual Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationFailureException ex)
            {
                await HandleValidationFailureException(context, ex);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private static Task HandleValidationFailureException(HttpContext context, ValidationFailureException ex)
        {
            //log.Error(ex);

            var contentResult = JsonContentResult.Error(new
            {
                ex.Content.ErrorCode,
                ex.Content.ErrorMessage
            });

            context.Response.ContentType = "application/json";

            context.Response.StatusCode = contentResult.StatusCode ?? (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(contentResult.Content);
        }

        private static Task HandleException(HttpContext context, Exception ex)
        {
            //log.Error(ex);

            var contentResult = JsonContentResult.Error(new
            {
                HttpStatusCode.InternalServerError,
                Message = $"Internal Server Error."
            });

            context.Response.ContentType = "application/json";

            context.Response.StatusCode = contentResult.StatusCode ?? (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(contentResult.Content);
        }
    }
}
