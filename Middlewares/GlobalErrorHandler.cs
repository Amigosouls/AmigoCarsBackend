﻿using AmigoCars.Exceptions;
using AmigoCars.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace AmigoCars.Middlewares
{
    public class GlobalErrorHandler:IMiddleware
    {
        private readonly ILogger<GlobalErrorHandler> _logger;
        public GlobalErrorHandler( ILogger<GlobalErrorHandler> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);                
                await HandleException(context, ex);
            }
            
        }

        private static Task HandleException(HttpContext context, Exception ex)
        {
            int statusCode = StatusCodes.Status500InternalServerError;
            switch (ex)
            {
                case NotFoundException _:
                    statusCode = StatusCodes.Status404NotFound;
                    break;
                case BadRequestException _:
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                case DivideByZeroException:
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
            }
            var errorResponse = new ErrorResponse
            {
                StatusCode = statusCode,
                Message = ex.Message,
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(errorResponse.ToString());
        }

    }

   
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionMiddlewear(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalErrorHandler>();
        }
    }
}
