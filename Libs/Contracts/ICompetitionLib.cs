using System.Collections.Generic;
using champi.Models.Competition;

namespace champi.Libs.Contracts
{
    public interface ICompetitionLib
    {
        List<CompetitionModel> GetCompetitions();
        CompetitionModel AddCompetition(AddCompetitionModel model);
        CompetitionModel UpdateCompetition(long competitionId, UpdateCompetitionModel model);
        bool DeleteCompetition(long competitionId);
    }
}