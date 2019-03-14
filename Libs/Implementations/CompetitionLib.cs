using System;
using System.Collections.Generic;
using System.Linq;
using champi.Context.Repository;
using champi.Domain.Entity.Competition;
using champi.Libs.Contracts;
using champi.Models.Competition;

namespace champi.Libs.Implementations
{
    public class CompetitionLib : ICompetitionLib
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Competition> competitionRepo;
        private readonly IRepository<CompetitionTeam> competitionTeamRepo;

        public CompetitionLib(
            IUnitOfWork unitOfWork,
            IRepository<Competition> competitionRepo,
            IRepository<CompetitionTeam> competitionTeamRepo
        )
        {
            this.unitOfWork = unitOfWork;
            this.competitionRepo = competitionRepo;
            this.competitionTeamRepo = competitionTeamRepo;
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

        public List<long> GetCompetitionTeamsId(long competitionId)
        {
            var result =
                competitionTeamRepo.GetAll()
                    .Where(x => x.CompetitionId == competitionId)
                    .Select(x => x.TeamId);

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

            return MapEntityToModel(entity);
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

            return MapEntityToModel(entity);
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

        private CompetitionModel MapEntityToModel(Competition entity)
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
    }
}