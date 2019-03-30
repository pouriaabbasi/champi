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
                for (int i = 0; i < teams.Count; i++)
                {
                    for (int j = i + 1; j < teams.Count; j++)
                    {
                        leagueMatchRepo.Add(new LeagueMatch
                        {
                            LeagueId = entity.Id,
                            FirstTeamId = teams[isNormal ? i : j].Id,
                            SecondTeamId = teams[isNormal ? j : i].Id,
                            MatchDate = entity.CompetitionStep.StartDate
                        });
                    }
                }
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

            UpdateLeagueResult(entity, model, winnnerId);

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

        private bool UpdateLeagueResult(LeagueMatch leagueMatch, SetMatchScoreModel model, long? winnnerId)
        {
            var leagueResults = leagueResultRepo.GetAll()
                .Where(x => x.LeagueId == leagueMatch.LeagueId);

            var firstTeam = leagueResults.First(x => x.LeagueTeamId == leagueMatch.FirstTeamId);
            var secondTeam = leagueResults.First(x => x.LeagueTeamId == leagueMatch.SecondTeamId);

            firstTeam.Won = firstTeam.Won + (winnnerId != null && winnnerId == firstTeam.LeagueTeamId ? 1 : 0);
            firstTeam.Points = firstTeam.Points + (winnnerId != null && winnnerId == firstTeam.LeagueTeamId ? 3 : 0);
            firstTeam.Draw = firstTeam.Draw + (winnnerId == null ? 1 : 0);
            firstTeam.Points = firstTeam.Points + (winnnerId == null ? 1 : 0);
            firstTeam.Lost = firstTeam.Lost + (winnnerId != null && winnnerId != firstTeam.LeagueTeamId ? 1 : 0);
            firstTeam.GoalsFor = firstTeam.GoalsFor + model.FirstTeamScore;
            firstTeam.GoalsAgainst = firstTeam.GoalsAgainst + model.SecondTeamScore;
            firstTeam.GoalDifference = firstTeam.GoalsFor - firstTeam.GoalsAgainst;
            firstTeam.Played++;

            secondTeam.Won = secondTeam.Won + (winnnerId != null && winnnerId == secondTeam.LeagueTeamId ? 1 : 0);
            secondTeam.Points = secondTeam.Points + (winnnerId != null && winnnerId == secondTeam.LeagueTeamId ? 3 : 0);
            secondTeam.Draw = secondTeam.Draw + (winnnerId == null ? 1 : 0);
            secondTeam.Points = secondTeam.Points + (winnnerId == null ? 1 : 0);
            secondTeam.Lost = secondTeam.Lost + (winnnerId != null && winnnerId != secondTeam.LeagueTeamId ? 1 : 0);
            secondTeam.GoalsFor = secondTeam.GoalsFor + model.SecondTeamScore;
            secondTeam.GoalsAgainst = secondTeam.GoalsAgainst + model.FirstTeamScore;
            secondTeam.GoalDifference = secondTeam.GoalsFor - secondTeam.GoalsAgainst;
            secondTeam.Played++;

            var rank = 1;
            foreach (var leagueResult in leagueResults
                .OrderByDescending(x => x.Points)
                .ThenByDescending(x => x.GoalDifference)
                .ThenByDescending(x => x.GoalsFor)
                .ThenByDescending(x => x.Won)
                .ThenBy(x => x.LeagueTeam.CompetitionTeam.Team.Name))
            {
                leagueResult.LeagueResultType = rank == 1 ? LeagueResultTypeKind.Champion : LeagueResultTypeKind.Fall;
                leagueResult.PreviousPosition = leagueResult.Rank;
                leagueResult.Rank = rank++;
            }

            unitOfWork.Commit();

            return true;
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
                LeagueTeams = entity.LeagueTeams
                    .Select(x => new LeagueTeamModel
                    {
                        CompetitionTeamId = x.CompetitionTeamId,
                        Id = x.Id,
                        //TODO:fill TeamName and TeamId
                        // TeamId = x.CompetitionTeam.TeamId,
                        // TeamName = x.CompetitionTeam.Team.Name
                    }).ToList()
            };
        }

    }
}