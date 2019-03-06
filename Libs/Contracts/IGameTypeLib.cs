using System.Collections.Generic;
using champi.Models.GameType;

namespace champi.Libs.Contracts
{
    public interface IGameTypeLib
    {
        List<GameTypeModel> GetGameTypes();
    }
}