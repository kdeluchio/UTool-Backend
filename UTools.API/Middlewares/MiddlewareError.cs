using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using UTools.Application.Dtos;

namespace UTools.API.Middlewares
{

    public class MiddlewareError
    {
        private readonly RequestDelegate next;
        private readonly ILogger _log;

        public MiddlewareError(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            _log = loggerFactory.CreateLogger("MiddlewareErrorLog");
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            ResponseDTO errorResponseVm;

            errorResponseVm = new ResponseDTO
            {
                HasError = true,
                Message = $"{ex.Message} {ex?.InnerException?.Message}"
            };

            _log.LogError($"Error: {ex.Message}");
            _log.LogError($"Stack: {ex.StackTrace}");

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            var result = JsonConvert.SerializeObject(errorResponseVm, jsonSettings);
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}
