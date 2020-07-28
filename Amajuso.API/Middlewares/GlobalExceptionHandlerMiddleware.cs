using Microsoft.AspNetCore.Http;
using Amajuso.Domain.Entities;
using Amajuso.Services;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Amajuso.Domain.Interfaces;

namespace SP.Metro.API.Middlewares
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
        IService<BlackList> _service;
        public GlobalExceptionHandlerMiddleware([FromServices]IService<BlackList> service)
        {
            _service = service;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            bool Continue = true;
            var token = context.Request.Headers["authorization"];
            token = string.IsNullOrWhiteSpace(token) ? "" : token.Single().Replace("Bearer ", "");

            if (!string.IsNullOrWhiteSpace(token))
            {
                Continue =  await _service.Exist(x => x.Token == token) ? !Continue : Continue;
            }

            if (Continue)
            {
                await next(context);
                return;
            }

            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

        }
    }
}