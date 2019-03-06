using System.Collections.Generic;
using champi.Models.Base;
using champi.Models.GameType;

namespace champi.Libs.Contracts
{
    public interface IGameTypeLib
    {
        List<GameTypeModel> GetGameTypes();
        GameTypeModel AddGameType(AddGameTypeModel model);
        GameTypeModel UpdateGameType(long gameTypeId, UpdateGameTypeModel model);
        bool DeleteGameType(long gameTypeId);
        List<BaseSelectionModel> GetGameTypeSelections();
    }
}