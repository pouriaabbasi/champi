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

        #region GET

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

        [HttpGet("{competitionId}")]
        public IActionResult GetCompetitionTeams(long competitionId)
        {
            try
            {
                var result = competitionLib.GetCompetitionTeams(competitionId);
                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet("{competitionId}")]
        public IActionResult GetCompetitionSteps(long competitionId)
        {
            try
            {
                var result = competitionLib.GetCompetitionSteps(competitionId);
                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet("{competitionStepId}")]
        public IActionResult GetCompetitionLeague(long competitionStepId)
        {
            try
            {
                var result = competitionLib.GetCompetitionLeague(competitionStepId);
                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet("{leagueId}")]
        public IActionResult GetLeagueMatches(long leagueId)
        {
            try
            {
                var result = competitionLib.GetLeagueMatches(leagueId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet("{competitionStepId}")]
        public IActionResult GetLeagueResult(long competitionStepId)
        {
            try
            {
                var result = competitionLib.GetLeagueResult(competitionStepId);
                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }

        #endregion

        #region POST

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

        [HttpPost]
        public IActionResult AddCompetitionLeague([FromBody] AddLeagueModel model)
        {
            try
            {
                if (!ModelState.IsValid) return CustomError(ModelState);

                var result = competitionLib.AddCompetitionLeague(model);
                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }

        #endregion

        #region PUT

        [HttpPut("{competitionId}")]
        public IActionResult UpdateCompetition(long competitionId, [FromBody] UpdateCompetitionModel model)
        {
            try
            {
                var result = competitionLib.UpdateCompetition(competitionId, model);
                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{competitionId}")]
        public IActionResult UpdateCompetitionTeams(long competitionId, [FromBody]UpdateCompetitionTeamsModel model)
        {
            try
            {
                var result = competitionLib.UpdateCompetitionTeams(competitionId, model);
                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{competitionId}")]
        public IActionResult UpdateCompetitionSteps(long competitionId, [FromBody]UpdateCompetitionStepsModel[] model)
        {
            try
            {
                var result = competitionLib.UpdateCompetitionSteps(competitionId, model);
                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{leagueId}")]
        public IActionResult UpdateCompetitionLeague(long leagueId, [FromBody]UpdateLeagueModel model)
        {
            try
            {
                if (!ModelState.IsValid) return CustomError(ModelState);

                var result = competitionLib.UpdateCompetitionLeague(leagueId, model);
                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{leagueId}")]
        public IActionResult GenerateLeagueGames(long leagueId)
        {
            try
            {
                var result = competitionLib.GenerateLeagueGames(leagueId);
                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{leagueMatchId}")]
        public IActionResult SetLeagueMatchScore(long leagueMatchId, [FromBody]SetMatchScoreModel model)
        {
            try
            {
                var result = competitionLib.SetLeagueMatchScore(leagueMatchId, model);
                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{competitionStepId}")]
        public IActionResult SetLeagueComplete(long competitionStepId)
        {
            try
            {
                var result = competitionLib.SetLeagueComplete(competitionStepId);
                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }

        #endregion

        #region DELETE

        [HttpDelete("{competitionId}")]
        public IActionResult DeleteCompetition(long competitionId)
        {
            try
            {
                var result = competitionLib.DeleteCompetition(competitionId);
                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }

        #endregion
    }
}