using System;
using System.Linq;
using champi.Domain.Enum;
using champi.Models.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace champi.Controllers.Base
{
    public class BaseController : Controller
    {
        protected IActionResult CustomResult(object result = null, string message = null)
        {
            return Ok(new BaseResult
            {
                Type = Domain.Enum.StatusCodeTypeKind.Ok,
                Message = message,
                Data = result
            });
        }

        private IActionResult CustomError(string error, StatusCodeTypeKind statusCode, object result)
        {
            return Ok(new BaseResult
            {
                Type = statusCode,
                Message = error,
                Data = result
            });
        }


        protected IActionResult CustomError(IdentityResult identityResult)
        {
            var error = string.Join(", ", identityResult.Errors
                    .Select(x => x.Description).ToArray());

            return CustomError(error, Domain.Enum.StatusCodeTypeKind.ApplicationError, null);
        }


        protected IActionResult CustomError(ModelStateDictionary modelState)
        {
            var error = string.Join(" ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(modelError => modelError.ErrorMessage).ToArray());

            return CustomError(error, Domain.Enum.StatusCodeTypeKind.UserError, null);
        }

        protected IActionResult CustomError(Exception exception)
        {
            return CustomError(exception.ToString(), Domain.Enum.StatusCodeTypeKind.ApplicationError, null);
        }


        protected IActionResult CustomError(object result, StatusCodeTypeKind statusCode)
        {
            return CustomError(null, statusCode, result);
        }


        protected IActionResult CustomError(string error)
        {
            return CustomError(error, Domain.Enum.StatusCodeTypeKind.UserError, null);
        }

    }
}