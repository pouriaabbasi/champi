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
    public class GameTypeController : BaseController
    {
        private readonly IGameTypeLib gameTypeLib;

        public GameTypeController(
            IGameTypeLib gameTypeLib
        )
        {
            this.gameTypeLib = gameTypeLib;
        }

        [HttpGet]
        public IActionResult GetGameTypes()
        {
            try
            {
                var result = gameTypeLib.GetGameTypes();
                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet]
        public IActionResult GetGameTypeSelections()
        {
            try
            {
                var result = gameTypeLib.GetGameTypeSelections();
                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPost]
        public IActionResult AddGameType([FromBody] AddGameTypeModel model)
        {
            try
            {
                if (!ModelState.IsValid) return CustomError(ModelState);

                var result = gameTypeLib.AddGameType(model);

                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{gameTypeId}")]
        public IActionResult UpdateGameType(long gameTypeId, [FromBody] UpdateGameTypeModel model)
        {
            try
            {
                if (!ModelState.IsValid) return CustomError(ModelState);

                var result = gameTypeLib.UpdateGameType(gameTypeId, model);

                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpDelete("{gameTypeId}")]
        public IActionResult DeleteGameType(long gameTypeId)
        {
            try
            {
                var result = gameTypeLib.DeleteGameType(gameTypeId);
                return CustomResult(result);
            }
            catch (Exception exp)
            {
                return CustomError(exp);
            }
        }
    }
}