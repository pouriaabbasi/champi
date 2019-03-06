using System.Collections.Generic;
using champi.Models.Base;
using champi.Models.Team;

namespace champi.Libs.Contracts
{
    public interface ITeamLib
    {
        List<TeamModel> GetTeams();
        List<BaseSelectionModel> GetTeamSelections();
        TeamModel AddTeam(AddTeamModel model);
        TeamModel UpdateTeam(long teamId, UpdateTeamModel model);
        bool DeleteTeam(long teamId);
    }
}