using System;
using champi.Controllers.Base;
using champi.Libs.Contracts;
using champi.Models.Team;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace champi.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class TeamController : BaseController
    {
        private readonly ITeamLib teamLib;

        public TeamController(
            ITeamLib teamLib
        )
        {
            this.teamLib = teamLib;
        }

        [HttpGet]
        public IActionResult GetTeams()
        {
            try
            {
                var result = teamLib.GetTeams();
                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet]
        public IActionResult GetTeamSelections()
        {
            try
            {
                var result = teamLib.GetTeamSelections();
                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPost]
        public IActionResult AddTeam([FromBody] AddTeamModel model)
        {
            try
            {
                if (!ModelState.IsValid) return CustomError(ModelState);

                var result = teamLib.AddTeam(model);
                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{teamId}")]
        public IActionResult UpdateTeam(long teamId, [FromBody] UpdateTeamModel model)
        {
            try
            {
                var result = teamLib.UpdateTeam(teamId, model);
                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpDelete("{teamId}")]
        public IActionResult DeleteTeam(long teamId)
        {
            try
            {
                var result = teamLib.DeleteTeam(teamId);
                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }
    }
}