using OnlineShop.Common.Exceptions;
using System.Net;
using System.Text.Json;

namespace OnlineShop.API.Middlewares
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException notFoundException)
            {
                await WriteErrorResponse(context, HttpStatusCode.NotFound, notFoundException.Message);
            }
            catch (BadRequestException badRequestException)
            {
                await WriteErrorResponse(context, HttpStatusCode.BadRequest, badRequestException.Message);
            }
            catch (AppException appException)
            {
                await WriteErrorResponse(context, HttpStatusCode.BadRequest, appException.Message);
            }
            catch (Exception exception)
            {
                await WriteErrorResponse(context, HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        public async Task WriteErrorResponse(HttpContext context, HttpStatusCode statusCode, string message)
        {
            var result = new ErrorResponse
            {
                StatusCode = statusCode,
                Message = message
            };

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            var json = JsonSerializer.Serialize(result, options);

            await context.Response.WriteAsync(json);
        }
    }
}
