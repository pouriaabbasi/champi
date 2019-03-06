using System.Collections.Generic;
using champi.Libs.Contracts;
using champi.Models.GameType;
using Microsoft.AspNetCore.Mvc;

namespace champi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class GameTypeController : Controller
    {
        private readonly IGameTypeLib gameTypeLib;

        public GameTypeController(
            IGameTypeLib gameTypeLib    
        )
        {
            this.gameTypeLib = gameTypeLib;
        }

        [HttpGet]
        public List<GameTypeModel> GetGameTypes()
        {
            return gameTypeLib.GetGameTypes();
        }
    }
}