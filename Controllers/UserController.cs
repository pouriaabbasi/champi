using champi.Controllers.Base;
using champi.Libs.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using champi.Models.User;
using System;

namespace champi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : BaseController
    {
        private readonly IUserLib userLib;

        public UserController(
            IUserLib userLib
        )
        {
            this.userLib = userLib;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel model)
        {
            try
            {
                var result = userLib.Login(model);
                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }
    }
}