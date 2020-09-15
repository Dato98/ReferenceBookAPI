using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace ReferenceBookAPI.Middlwares
{
    public class ErrorLoggingMiddleware 
    {
        private readonly RequestDelegate _next;
        private readonly ILogger logger;

        public ErrorLoggingMiddleware(RequestDelegate next,ILoggerFactory loggerFactory)
        {
            _next = next;
            logger = loggerFactory.CreateLogger<ErrorLoggingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                logger.LogInformation(ex.Message);
            }
        }


    }
}
