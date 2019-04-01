using System;
using System.Collections.Generic;
using System.Linq;
using champi.Context.Repository;
using champi.Domain.Entity.Competition;
using champi.Domain.Enum;
using champi.Libs.Contracts;
using champi.Libs.Extensions;
using champi.Models.Competition;

namespace champi.Libs.Implementations
{
    public class CompetitionLib : ICompetitionLib
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Competition> competitionRepo;
        private readonly IRepository<CompetitionTeam> competitionTeamRepo;
        private readonly IRepository<CompetitionStep> competitionStepRepo;
        private readonly IRepository<League> leagueRepo;
        private readonly IRepository<LeagueTeam> leagueTeamRepo;
        private readonly IRepository<LeagueMatch> leagueMatchRepo;
        private readonly IRepository<LeagueResult> leagueResultRepo;

        public CompetitionLib(
            IUnitOfWork unitOfWork,
            IRepository<Competition> competitionRepo,
            IRepository<CompetitionTeam> competitionTeamRepo,
            IRepository<CompetitionStep> competitionStepRepo,
            IRepository<League> leagueRepo,
            IRepository<LeagueTeam> leagueTeamRepo,
            IRepository<LeagueMatch> leagueMatchRepo,
            IRepository<LeagueResult> leagueResultRepo
        )
        {
            this.unitOfWork = unitOfWork;
            this.competitionRepo = competitionRepo;
            this.competitionTeamRepo = competitionTeamRepo;
            this.competitionStepRepo = competitionStepRepo;
            this.leagueRepo = leagueRepo;
            this.leagueTeamRepo = leagueTeamRepo;
            this.leagueMatchRepo = leagueMatchRepo;
            this.leagueResultRepo = leagueResultRepo;
        }

        #region Public
        public List<CompetitionModel> GetCompetitions()
        {
            var result =
                competitionRepo
                    .GetAll()
                    .Select(x => new CompetitionModel
                    {
                        EndDate = x.EndDate,
                        GameTypeId = x.GameTypeId,
                        GameTypeName = x.GameType.Name,
                        Id = x.Id,
                        StartDate = x.StartDate,
                        TeamCount = x.TeamCount,
                        ChampionTeamId = x.ChampionTeamId,
                        ChampionTeamName = x.ChampionTeam == null ? string.Empty : x.ChampionTeam.Name,
                        IsCompleted = x.IsCompleted,
                        IsStarted = x.IsStarted,
                        Iteration = x.Iteration,
                        Name = x.Name
                    });

            return result.ToList();
        }

        public List<CompetitionTeamModel> GetCompetitionTeams(long competitionId)
        {
            var result =
                competitionTeamRepo.GetAll()
                    .Where(x => x.CompetitionId == competitionId)
                    .Select(x => new CompetitionTeamModel
                    {
                        Id = x.Id,
                        CompetitionId = x.CompetitionId,
                        TeamId = x.TeamId,
                        TeamName = x.Team.Name
                    });

            return result.ToList();
        }

        public CompetitionModel AddCompetition(AddCompetitionModel model)
        {
            var entity = new Competition
            {
                EndDate = model.EndDate,
                GameTypeId = model.GameTypeId,
                IsCompleted = model.IsCompleted,
                IsStarted = model.IsStarted,
                Iteration = CalculateIteration(model.Name, model.GameTypeId),
                Name = model.Name,
                StartDate = model.StartDate
            };

            competitionRepo.Add(entity);
            unitOfWork.Commit();

            return MapEntityToCompetitionModel(entity);
        }

        public CompetitionModel UpdateCompetition(long competitionId, UpdateCompetitionModel model)
        {
            var entity = competitionRepo.FirstOrDefault(x => x.Id == competitionId);
            if (entity == null) throw new Exception("Item Not Found");

            entity.Name = model.Name;
            entity.EndDate = model.EndDate;
            entity.GameTypeId = model.GameTypeId;
            entity.IsCompleted = model.IsCompleted;
            entity.IsStarted = model.IsStarted;
            entity.Name = model.Name;
            entity.StartDate = model.StartDate;

            unitOfWork.Commit();

            return MapEntityToCompetitionModel(entity);
        }

        public bool UpdateCompetitionTeams(long competitionId, UpdateCompetitionTeamsModel model)
        {
            var competition = competitionRepo.FirstOrDefault(x => x.Id == competitionId);
            if (competition == null) throw new Exception("Item Not Found");

            competition.TeamCount = model.TeamsId.Length;

            var competitionTeams =
                competitionTeamRepo
                    .GetAll()
                    .Where(x => x.CompetitionId == competitionId);

            foreach (var competitionTeam in competitionTeams)
                competitionTeamRepo.Delete(competitionTeam);

            foreach (var teamId in model.TeamsId)
            {
                competitionTeamRepo.Add(new CompetitionTeam
                {
                    CompetitionId = competitionId,
                    TeamId = teamId
                });
            }

            unitOfWork.Commit();

            return true;
        }

        public bool DeleteCompetition(long competitionId)
        {
            var entity = competitionRepo.FirstOrDefault(x => x.Id == competitionId);
            if (entity == null) throw new Exception("Item Not Found");

            competitionRepo.Delete(entity);
            unitOfWork.Commit();

            return true;
        }

        public bool UpdateCompetitionSteps(long competitionId, UpdateCompetitionStepsModel[] models)
        {
            var competitionSteps =
                competitionStepRepo
                    .GetAll()
                    .Where(x => x.CompetitionId == competitionId);

            foreach (var competitionStep in competitionSteps)
                competitionStepRepo.Delete(competitionStep);

            var step = 1;
            foreach (var model in models)
            {
                competitionStepRepo.Add(new CompetitionStep
                {
                    CompetitionId = competitionId,
                    CompetitionType = model.CompetitionType,
                    EndDate = model.EndDate,
                    IsCompleted = model.IsCompleted,
                    IsStarted = model.IsStarted,
                    StartDate = model.StartDate,
                    Step = step++
                });
            }

            unitOfWork.Commit();

            return true;
        }

        public List<CompetitionStepModel> GetCompetitionSteps(long competitionId)
        {
            var result =
                competitionStepRepo.GetAll()
                    .Where(x => x.CompetitionId == competitionId)
                    .OrderBy(x => x.Step)
                    .Select(x => new CompetitionStepModel
                    {
                        CompetitionId = x.CompetitionId,
                        CompetitionType = x.CompetitionType,
                        CompetitionTypeString = x.CompetitionType.ToString(),
                        EndDate = x.EndDate,
                        Id = x.Id,
                        IsCompleted = x.IsCompleted,
                        IsStarted = x.IsStarted,
                        StartDate = x.StartDate,
                        Step = x.Step
                    });

            return result.ToList();
        }

        public LeagueModel GetCompetitionLeague(long competitionStepId)
        {
            var competitionStepEntity =
                competitionStepRepo.FirstOrDefault(x => x.Id == competitionStepId);
            if (competitionStepEntity == null)
                return null;
            if (competitionStepEntity.CompetitionType != CompetitionTypeKind.League)
                return null;

            var leagueEntity =
                leagueRepo.FirstOrDefault(x => x.CompetitionStepId == competitionStepId);
            if (leagueEntity == null)
                return null;

            return new LeagueModel
            {
                CompetitionStepId = leagueEntity.CompetitionStepId,
                FallTeamCount = leagueEntity.FallTeamCount,
                Id = leagueEntity.Id,
                IsHomeAway = leagueEntity.IsHomeAway,
                PeerToPeerPlayCount = leagueEntity.PeerToPeerPlayCount,
                RiseTeamCount = leagueEntity.RiseTeamCount,
                TeamCount = leagueEntity.TeamCount,
                DrawPoint = leagueEntity.DrawPoint,
                LostPoint = leagueEntity.LostPoint,
                WonPoint = leagueEntity.WonPoint,
                LeagueTeams = GetLeagueTeams(leagueEntity.Id)
            };
        }

        public LeagueModel AddCompetitionLeague(AddLeagueModel model)
        {
            var entity = new League
            {
                CompetitionStepId = model.CompetitionStepId,
                FallTeamCount = model.FallTeamCount,
                IsHomeAway = model.IsHomeAway,
                PeerToPeerPlayCount = model.PeerToPeerPlayCount,
                RiseTeamCount = model.RiseTeamCount,
                TeamCount = model.TeamCount,
                DrawPoint = model.DrawPoint,
                LostPoint = model.LostPoint,
                WonPoint = model.WonPoint,
                LeagueTeams = model.LeagueTeams
                    .Select(x => new LeagueTeam
                    {
                        CompetitionTeamId = x.CompetitionTeamId
                    }).ToList()
            };

            leagueRepo.Add(entity);

            unitOfWork.Commit();

            return MapEntityToLegaueModel(entity);
        }

        public LeagueModel UpdateCompetitionLeague(long leagueId, UpdateLeagueModel model)
        {
            var entity = leagueRepo.FirstOrDefault(x => x.Id == leagueId);
            if (entity == null) throw new Exception("Item Not Found");

            entity.IsHomeAway = model.IsHomeAway;
            entity.FallTeamCount = model.FallTeamCount;
            entity.PeerToPeerPlayCount = model.PeerToPeerPlayCount;
            entity.RiseTeamCount = model.RiseTeamCount;
            entity.TeamCount = model.TeamCount;
            entity.WonPoint = model.WonPoint;
            entity.DrawPoint = model.DrawPoint;
            entity.LostPoint = model.LostPoint;
            foreach (var leagueTeam in entity.LeagueTeams)
                leagueTeamRepo.Delete(leagueTeam);
            entity.LeagueTeams = new List<LeagueTeam>();
            foreach (var leagueTeam in model.LeagueTeams)
                entity.LeagueTeams.Add(new LeagueTeam
                {
                    CompetitionTeamId = leagueTeam.CompetitionTeamId,
                    LeagueId = entity.Id
                });

            unitOfWork.Commit();

            return MapEntityToLegaueModel(entity);
        }

        public List<LeagueMatchModel> GenerateLeagueGames(long leagueId)
        {
            var entity = leagueRepo.FirstOrDefault(x => x.Id == leagueId);
            if (entity == null) throw new Exception("Item Not Found!");

            var teams = entity.LeagueTeams.ToList();
            teams.Shuffle();

            for (int k = 0; k < entity.PeerToPeerPlayCount; k++)
            {
                var isNormal = k % 2 == 0;
                leagueMatchRepo.AddRange(GenerateLeagueMatchs(isNormal, teams, entity));
            }

            unitOfWork.Commit();

            GenerateLeagueResult(leagueId);

            return GetLeagueMatches(leagueId);
        }

        public List<LeagueMatchModel> GetLeagueMatches(long leagueId)
        {
            var result =
                leagueMatchRepo.GetAll()
                    .Where(x => x.LeagueId == leagueId)
                    .Select(x => new LeagueMatchModel
                    {
                        FirstTeamId = x.FirstTeamId,
                        FirstTeamName = x.FirstTeam.CompetitionTeam.Team.Name,
                        FirstTeamScore = x.FirstTeamScore,
                        Id = x.Id,
                        MatchDate = x.MatchDate,
                        SecondTeamId = x.SecondTeamId,
                        SecondTeamName = x.SecondTeam.CompetitionTeam.Team.Name,
                        SecondTeamScore = x.SecondTeamScore,
                        WinnerTeamId = x.WinnerTeamId,
                        WinnerTeamName = x.WinnerTeamId == null ? "" : x.WinnerTeam.CompetitionTeam.Team.Name
                    });

            return result.ToList();
        }

        public bool SetLeagueMatchScore(long leagueMatchId, SetMatchScoreModel model)
        {
            var entity = leagueMatchRepo.FirstOrDefault(x => x.Id == leagueMatchId);
            if (entity == null) throw new Exception("Item Not Found");

            var winnnerId =
                model.FirstTeamScore == model.SecondTeamScore
                    ? null
                    : (long?)(model.FirstTeamScore > model.SecondTeamScore
                        ? entity.FirstTeamId
                        : entity.SecondTeamId);

            entity.FirstTeamScore = model.FirstTeamScore;
            entity.SecondTeamScore = model.SecondTeamScore;
            entity.WinnerTeamId = winnnerId;

            unitOfWork.Commit();

            UpdateLeagueResult(entity.LeagueId);

            return true;
        }

        public List<LeagueResultModel> GetLeagueResult(long competitionStepId)
        {
            var result = leagueResultRepo.GetAll()
                .Where(x => x.League.CompetitionStepId == competitionStepId)
                .OrderBy(x => x.Rank)
                .Select(x => new LeagueResultModel
                {
                    Draw = x.Draw,
                    GoalDifference = x.GoalDifference,
                    GoalsAgainst = x.GoalsAgainst,
                    GoalsFor = x.GoalsFor,
                    Id = x.Id,
                    LeagueId = x.LeagueId,
                    LeagueResultType = x.LeagueResultType,
                    LeagueTeamId = x.LeagueTeamId,
                    Lost = x.Lost,
                    LeagueTeamName = x.LeagueTeam.CompetitionTeam.Team.Name,
                    Played = x.Played,
                    Points = x.Points,
                    PreviousPosition = x.PreviousPosition,
                    Rank = x.Rank,
                    Won = x.Won
                });

            return result.ToList();
        }

        public bool SetLeagueComplete(long competitionStepId)
        {
            var league = leagueRepo.FirstOrDefault(x => x.CompetitionStepId == competitionStepId);
            if (league == null) throw new Exception("Item Not Found");

            foreach (var leagueMatch in league.LeagueMatches.Where(x => x.FirstTeamScore == null))
                leagueMatchRepo.Delete(leagueMatch);

            var isLastStep = competitionStepRepo.GetAll()
                .Count(x =>
                    x.Id > league.CompetitionStepId
                    && x.CompetitionId == league.CompetitionStep.CompetitionId);

            if (isLastStep == 0)
                SetCompetitionChampoin(league);

            unitOfWork.Commit();

            return true;
        }

        public List<LeagueMatchModel> GenerateExtraRound(long leagueId)
        {
            var league = leagueRepo.FirstOrDefault(x => x.Id == leagueId);
            if (league == null) throw new Exception("Item Not Found");

            var hasOpenMatch = leagueMatchRepo.GetAll()
                .Any(x =>
                    x.LeagueId == leagueId
                    && x.FirstTeamScore == null);
            if (hasOpenMatch) throw new Exception("We have open matches, it's not possible to create extra round!");

            var maxleagueResultPoint = leagueResultRepo.GetAll()
                .Where(x => x.LeagueId == leagueId)
                .Max(x => x.Points);

            var teams = leagueResultRepo.GetAll()
                .Where(x =>
                    x.LeagueId == leagueId
                    && x.Points == maxleagueResultPoint)
                .Select(x => x.LeagueTeam)
                .ToList();

            teams.Shuffle();

            leagueMatchRepo.AddRange(GenerateLeagueMatchs(true, teams, league));

            unitOfWork.Commit();

            return GetLeagueMatches(leagueId);
        }

        #endregion

        #region Private
        private void SetCompetitionChampoin(League league)
        {
            var championTeam = league.LeagueResults.OrderBy(x => x.Rank).First();
            league.CompetitionStep.Competition.ChampionTeamId = championTeam.LeagueTeam.CompetitionTeam.TeamId;
        }

        private bool UpdateLeagueResult(long leagueId)
        {
            var league = leagueRepo.FirstOrDefault(x => x.Id == leagueId);
            if (league == null) throw new Exception("Item Not Found");

            var leagueResults = leagueResultRepo.GetAll()
                .Where(x => x.LeagueId == leagueId)
                .Select(x => x);

            var leagueMatches = leagueMatchRepo.GetAll()
                .Where(x =>
                    x.LeagueId == leagueId
                    && x.FirstTeamScore != null)
                .Select(x => x);

            ResetLeagueResults(leagueResults);

            foreach (var leagueMatch in leagueMatches)
                UpdateLeagueResult(leagueResults, leagueMatch, league);

            UpdateLeagueResultRank(leagueResults, league);

            unitOfWork.Commit();

            return true;
        }

        private void UpdateLeagueResultRank(IEnumerable<LeagueResult> leagueResults, League league)
        {
            var rank = 1;
            var rankedLeagueResults = leagueResults
                .OrderByDescending(x => x.Points)
                .ThenByDescending(x => x.GoalDifference)
                .ThenByDescending(x => x.GoalsFor)
                .ThenBy(x => x.Played)
                .ThenBy(x => x.LeagueTeam.CompetitionTeam.Team.Name);

            foreach (var result in rankedLeagueResults)
            {
                result.PreviousPosition = result.Rank;
                result.Rank = rank++;
            }

            rankedLeagueResults.First().LeagueResultType = LeagueResultTypeKind.Champion;
            foreach (var riseResult in rankedLeagueResults.Skip(1).Take(league.RiseTeamCount - 1))
                riseResult.LeagueResultType = LeagueResultTypeKind.Rise;

            foreach (var fallResult in rankedLeagueResults.TakeLast(league.FallTeamCount))
                fallResult.LeagueResultType = LeagueResultTypeKind.Fall;
        }

        private void UpdateLeagueResult(IEnumerable<LeagueResult> leagueResults, LeagueMatch leagueMatch, League league)
        {
            var firstTeam = leagueResults.First(x => x.LeagueTeamId == leagueMatch.FirstTeamId);
            var secondTeam = leagueResults.First(x => x.LeagueTeamId == leagueMatch.SecondTeamId);

            firstTeam.GoalsFor += leagueMatch.FirstTeamScore ?? 0;
            firstTeam.GoalsAgainst += leagueMatch.SecondTeamScore ?? 0;
            firstTeam.GoalDifference += (leagueMatch.FirstTeamScore ?? 0) - (leagueMatch.SecondTeamScore ?? 0);
            firstTeam.Played++;

            secondTeam.GoalsFor += leagueMatch.SecondTeamScore ?? 0;
            secondTeam.GoalsAgainst += leagueMatch.FirstTeamScore ?? 0;
            secondTeam.GoalDifference += (leagueMatch.SecondTeamScore ?? 0) - (leagueMatch.FirstTeamScore ?? 0);
            secondTeam.Played++;

            if (leagueMatch.WinnerTeamId == null)
            {
                firstTeam.Draw++;
                firstTeam.Points += league.DrawPoint;
                secondTeam.Draw++;
                secondTeam.Points += league.DrawPoint;
            }
            else
            {
                var isFirstWinner = leagueMatch.WinnerTeamId == firstTeam.LeagueTeamId;

                firstTeam.Won += isFirstWinner ? 1 : 0;
                firstTeam.Lost += isFirstWinner ? 0 : 1;
                firstTeam.Points += isFirstWinner ? league.WonPoint : league.LostPoint;

                secondTeam.Won += isFirstWinner ? 0 : 1;
                secondTeam.Lost += isFirstWinner ? 1 : 0;
                secondTeam.Points += isFirstWinner ? league.LostPoint : league.WonPoint;
            }
        }

        private void ResetLeagueResults(IEnumerable<LeagueResult> leagueResults)
        {
            foreach (var leagueResult in leagueResults)
            {
                leagueResult.LeagueResultType = LeagueResultTypeKind.Normal;
                leagueResult.Lost = 0;
                leagueResult.Played = 0;
                leagueResult.Points = 0;
                leagueResult.Won = 0;
                leagueResult.Draw = 0;
                leagueResult.GoalDifference = 0;
                leagueResult.GoalsAgainst = 0;
                leagueResult.GoalsFor = 0;
            }
        }

        private bool GenerateLeagueResult(long leagueId)
        {
            var leagueTeams = GetLeagueTeams(leagueId).OrderBy(x => x.TeamName);

            var counter = 1;

            foreach (var leagueTeam in leagueTeams)
            {
                leagueResultRepo.Add(new LeagueResult
                {
                    Draw = 0,
                    GoalDifference = 0,
                    GoalsAgainst = 0,
                    GoalsFor = 0,
                    LeagueId = leagueId,
                    LeagueResultType = LeagueResultTypeKind.Rise,
                    LeagueTeamId = leagueTeam.Id,
                    Lost = 0,
                    Played = 0,
                    Points = 0,
                    PreviousPosition = 0,
                    Rank = counter++,
                    Won = 0
                });
            }

            unitOfWork.Commit();

            return true;
        }

        private List<LeagueTeamModel> GetLeagueTeams(long leagueId)
        {
            return leagueTeamRepo.GetAll()
                .Where(x => x.LeagueId == leagueId)
                .Select(x => new LeagueTeamModel
                {
                    Id = x.Id,
                    CompetitionTeamId = x.CompetitionTeamId,
                    TeamId = x.CompetitionTeam.TeamId,
                    TeamName = x.CompetitionTeam.Team.Name
                })
                .ToList();
        }

        private int CalculateIteration(string name, long gameTypeId)
        {
            var count =
                competitionRepo
                    .GetAll()
                    .Count(x =>
                        x.Name == name
                        && x.GameTypeId == gameTypeId);
            return ++count;
        }

        private CompetitionModel MapEntityToCompetitionModel(Competition entity)
        {
            return new CompetitionModel
            {
                ChampionTeamId = entity.ChampionTeamId,
                EndDate = entity.EndDate,
                GameTypeId = entity.GameTypeId,
                Id = entity.Id,
                IsCompleted = entity.IsCompleted,
                IsStarted = entity.IsStarted,
                Iteration = entity.Iteration,
                Name = entity.Name,
                StartDate = entity.StartDate,
                TeamCount = entity.TeamCount
            };
        }

        private LeagueModel MapEntityToLegaueModel(League entity)
        {
            return new LeagueModel
            {
                CompetitionStepId = entity.CompetitionStepId,
                FallTeamCount = entity.FallTeamCount,
                Id = entity.Id,
                IsHomeAway = entity.IsHomeAway,
                PeerToPeerPlayCount = entity.PeerToPeerPlayCount,
                RiseTeamCount = entity.RiseTeamCount,
                TeamCount = entity.TeamCount,
                DrawPoint = entity.DrawPoint,
                LostPoint = entity.LostPoint,
                WonPoint = entity.WonPoint,
                // LeagueTeams = GetLeagueTeams(entity.Id)
            };
        }

        private List<LeagueMatch> GenerateLeagueMatchs(bool isNormal, List<LeagueTeam> teams, League leagueEntity)
        {
            var result = new List<LeagueMatch>();
            for (int i = 0; i < teams.Count; i++)
            {
                for (int j = i + 1; j < teams.Count; j++)
                {
                    result.Add(new LeagueMatch
                    {
                        LeagueId = leagueEntity.Id,
                        FirstTeamId = teams[isNormal ? i : j].Id,
                        SecondTeamId = teams[isNormal ? j : i].Id,
                        MatchDate = leagueEntity.CompetitionStep.StartDate
                    });
                }
            }

            return result;
        }

        #endregion

    }
}