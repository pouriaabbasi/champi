using System;
using System.Collections.Generic;
using System.Linq;
using champi.Context.Repository;
using champi.Domain.Entity.Competition;
using champi.Libs.Contracts;
using champi.Models.Base;
using champi.Models.Team;

namespace champi.Libs.Implementations
{
    public class TeamLib : ITeamLib
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Team> teamRepo;

        public TeamLib(
            IUnitOfWork unitOfWork,
            IRepository<Team> teamRepo
        )
        {
            this.unitOfWork = unitOfWork;
            this.teamRepo = teamRepo;
        }

        public List<TeamModel> GetTeams()
        {
            var result =
                teamRepo
                    .GetAll()
                    .Select(x => new TeamModel
                    {
                        Id = x.Id,
                        AbbreviationName = x.AbbreviationName,
                        Logo = x.Logo,
                        Name = x.Name
                    });

            return result.ToList();
        }

        public List<BaseSelectionModel> GetTeamSelections()
        {
            var result =
                teamRepo
                    .GetAll()
                    .Select(x => new BaseSelectionModel
                    {
                        Caption = $"{x.Name}({x.AbbreviationName})",
                        Key = x.Id
                    });

            return result.ToList();
        }

        public TeamModel AddTeam(AddTeamModel model)
        {
            var entity = new Team
            {
                AbbreviationName = model.AbbreviationName,
                Logo = model.Logo,
                Name = model.Name
            };

            teamRepo.Add(entity);
            unitOfWork.Commit();

            return MapEntityToModel(entity);
        }

        public TeamModel UpdateTeam(long teamId, UpdateTeamModel model)
        {
            var entity = teamRepo.FirstOrDefault(x => x.Id == teamId);
            if (entity == null) throw new Exception("Item Not Found");

            entity.AbbreviationName = model.AbbreviationName;
            entity.Logo = model.Logo;
            entity.Name = model.Name;

            unitOfWork.Commit();

            return MapEntityToModel(entity);
        }

        public bool DeleteTeam(long teamId)
        {
            var entity = teamRepo.FirstOrDefault(x => x.Id == teamId);
            if (entity == null) throw new Exception("Item Not Found");

            teamRepo.Delete(entity);
            unitOfWork.Commit();

            return true;
        }

        private TeamModel MapEntityToModel(Team entity)
        {
            return new TeamModel
            {
                AbbreviationName = entity.AbbreviationName,
                Id = entity.Id,
                Logo = entity.Logo,
                Name = entity.Name
            };
        }
    }
}