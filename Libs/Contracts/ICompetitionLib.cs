using System.Collections.Generic;
using champi.Models.Competition;

namespace champi.Libs.Contracts
{
    public interface ICompetitionLib
    {
        List<CompetitionModel> GetCompetitions();
        List<long> GetCompetitionTeamsId(long competitionId);
        CompetitionModel AddCompetition(AddCompetitionModel model);
        CompetitionModel UpdateCompetition(long competitionId, UpdateCompetitionModel model);
        bool UpdateCompetitionTeams(long competitionId, UpdateCompetitionTeamsModel model);
        bool DeleteCompetition(long competitionId);
        bool UpdateCompetitionSteps(long competitionId, UpdateCompetitionStepsModel[] models);
        List<CompetitionStepModel> GetCompetitionSteps(long competitionId);
    }
}