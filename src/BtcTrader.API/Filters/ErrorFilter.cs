using BtcTrader.API.Models;
using BtcTrader.Application.Exceptions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using System.Net;

namespace BtcTrader.API.Filters
{
    public class ErrorFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exceptionModel = new ExceptionModel()
            {
                Message = context.Exception.Message,
            };
            switch (context.Exception)
            {
                case NotFoundException:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case BadRequestException:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case UnauthorizedException:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;
                default:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;

            }
            context.Result = new ObjectResult(exceptionModel);
        }
    }
}
