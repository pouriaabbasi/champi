using System.Collections.Generic;
using champi.Models.Competition;

namespace champi.Libs.Contracts
{
    public interface ICompetitionLib
    {
        List<CompetitionModel> GetCompetitions();
        List<CompetitionTeamModel> GetCompetitionTeams(long competitionId);
        CompetitionModel AddCompetition(AddCompetitionModel model);
        CompetitionModel UpdateCompetition(long competitionId, UpdateCompetitionModel model);
        bool UpdateCompetitionTeams(long competitionId, UpdateCompetitionTeamsModel model);
        bool DeleteCompetition(long competitionId);
        bool UpdateCompetitionSteps(long competitionId, UpdateCompetitionStepsModel[] models);
        List<CompetitionStepModel> GetCompetitionSteps(long competitionId);
        LeagueModel GetCompetitionLeague(long competitionStepId);
        LeagueModel AddCompetitionLeague(AddLeagueModel model);
        LeagueModel UpdateCompetitionLeague(long leagueId, UpdateLeagueModel model);
        List<LeagueMatchModel> GenerateLeagueGames(long leagueId);
        List<LeagueMatchModel> GetLeagueMatches(long leagueId);
        bool SetLeagueMatchScore(long leagueMatchId, SetMatchScoreModel model);
        List<LeagueResultModel> GetLeagueResult(long competitinoStepId);
        bool SetLeagueComplete(long competitionStepId);
        List<LeagueMatchModel> GenerateExtraRound(long leagueId);
    }
}