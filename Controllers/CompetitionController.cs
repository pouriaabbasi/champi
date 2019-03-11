using System;
using champi.Controllers.Base;
using champi.Libs.Contracts;
using champi.Models.Competition;
using champi.Models.Team;
using Microsoft.AspNetCore.Mvc;

namespace champi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CompetitionController : BaseController
    {
        private readonly ICompetitionLib competitionLib;

        public CompetitionController(
            ICompetitionLib competitionLib
        )
        {
            this.competitionLib = competitionLib;
        }

        [HttpGet]
        public IActionResult GetCompetitions()
        {
            try
            {
                var result = competitionLib.GetCompetitions();
                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }

        // [HttpGet]
        // public IActionResult GetTeamSelections()
        // {
        //     try
        //     {
        //         var result = teamLib.GetTeamSelections();
        //         return CustomResult(result);
        //     }
        //     catch (Exception exp)
        //     {
        //         return CustomError(exp);
        //     }
        // }

        [HttpPost]
        public IActionResult AddCompetition([FromBody] AddCompetitionModel model)
        {
            try
            {
                if (!ModelState.IsValid) return CustomError(ModelState);

                var result = competitionLib.AddCompetition(model);
                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }

        // [HttpPut("{teamId}")]
        // public IActionResult UpdateTeam(long teamId, [FromBody] UpdateTeamModel model)
        // {
        //     try
        //     {
        //         var result = teamLib.UpdateTeam(teamId, model);
        //         return CustomResult(result);
        //     }
        //     catch (Exception exp)
        //     {
        //         return CustomError(exp);
        //     }
        // }

        // [HttpDelete("{teamId}")]
        // public IActionResult DeleteTeam(long teamId)
        // {
        //     try
        //     {
        //         var result = teamLib.DeleteTeam(teamId);
        //         return CustomResult(result);
        //     }
        //     catch (Exception exp)
        //     {
        //         return CustomError(exp);
        //     }
        // }
    }
}