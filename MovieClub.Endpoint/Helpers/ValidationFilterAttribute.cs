﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Water.Entities.Helpers;

namespace Water.Endpoint.Helpers
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                //context.Result = new UnprocessableEntityObjectResult(context.ModelState);
                var error = new ErrorModel
                (
                    String.Join(',',
                    (context.ModelState.Values.SelectMany(t => t.Errors.Select(z => z.ErrorMessage))).ToArray())
                ) ;
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new JsonResult(error);
            }
        }
        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
