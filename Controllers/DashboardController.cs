using System;
using System.Collections.Generic;
using champi.Controllers.Base;
using champi.Libs.Contracts;
using champi.Models.GameType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace champi.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class DashboardController : BaseController
    {
        private readonly IDashboardLib dashboardLib;

        public DashboardController(
            IDashboardLib dashboardLib
        )
        {
            this.dashboardLib = dashboardLib;
        }

        [HttpGet]
        public IActionResult GetStatistics()
        {
            try
            {
                var result = dashboardLib.GetStatistics();
                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }
    }
}