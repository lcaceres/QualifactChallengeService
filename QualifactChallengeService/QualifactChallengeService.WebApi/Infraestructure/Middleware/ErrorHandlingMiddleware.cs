﻿using Newtonsoft.Json;
using QualifactChallengeService.WebApi.DTOs;
using System.Net;
using System.Net.Mime;
using Timeportal.Infrastructure.Exceptions;

namespace QualifactChallengeService.WebApi.Infraestructure.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var (statusCode, error) = GetErrorResponse(exception);
            var result = JsonConvert.SerializeObject(error);

            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(result);
        }

        private static (HttpStatusCode, ErrorResponse) GetErrorResponse(Exception exception)
        {
            string exceptionMessage;
            string userMessage;
            var type = exception.GetType();
            HttpStatusCode statusCode;

            switch (exception)
            {
                case BusinessRuleValidationException:
                    exceptionMessage = exception.Message;
                    userMessage = exception.Message;
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case ApplicationArgumentException:
                    exceptionMessage = exception.Message;
                    userMessage = exception.Message;
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case InvalidApplicationOperationException:
                    exceptionMessage = exception.Message;
                    userMessage = exception.Message;
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                default:
                    exceptionMessage = exception.Message;
                    userMessage = exception.Message;
                    statusCode = HttpStatusCode.InternalServerError;
                    type = typeof(Exception);
                    break;
            }

            return (statusCode, new ErrorResponse
            {
                ExceptionMessage = exceptionMessage,
                Message = userMessage,
                ExceptionType = type,
            });
        }
    }
}
