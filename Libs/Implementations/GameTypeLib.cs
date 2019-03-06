using System;
using System.Collections.Generic;
using System.Linq;
using champi.Context.Repository;
using champi.Domain.Entity.Competition;
using champi.Libs.Contracts;
using champi.Models.Base;
using champi.Models.GameType;

namespace champi.Libs.Implementations
{
    public class GameTypeLib : IGameTypeLib
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<GameType> gameTypeRepo;

        public GameTypeLib(
            IUnitOfWork unitOfWork,
            IRepository<GameType> gameTypeRepo
        )
        {
            this.unitOfWork = unitOfWork;
            this.gameTypeRepo = gameTypeRepo;
        }

        public List<GameTypeModel> GetGameTypes()
        {
            var result =
                gameTypeRepo
                    .GetAll()
                    .Select(x => new GameTypeModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        ParentGameTypeId = x.ParentGameTypeId
                    })
                    .ToList();
            return result;
        }

        public GameTypeModel AddGameType(AddGameTypeModel model)
        {
            var entity = new GameType
            {
                Name = model.Name,
                ParentGameTypeId = model.ParentGameTypeId
            };

            gameTypeRepo.Add(entity);
            unitOfWork.Commit();

            return MapEntityToModel(entity);
        }

        public GameTypeModel UpdateGameType(long gameTypeId, UpdateGameTypeModel model)
        {
            var entity = gameTypeRepo.FirstOrDefault(x => x.Id == gameTypeId);
            if (entity == null) throw new Exception("Item Not Found");

            entity.Name = model.Name;
            entity.ParentGameTypeId = model.ParentGameTypeId;

            unitOfWork.Commit();

            return MapEntityToModel(entity);
        }

        public bool DeleteGameType(long gameTypeId)
        {
            var entity = gameTypeRepo.FirstOrDefault(x => x.Id == gameTypeId);
            if (entity == null) throw new Exception("Item Not Found");

            gameTypeRepo.Delete(entity);
            unitOfWork.Commit();

            return true;
        }

        public List<BaseSelectionModel> GetGameTypeSelections()
        {
            var result =
                gameTypeRepo
                .GetAll()
                .Select(x => new BaseSelectionModel
                {
                    Key = x.Id,
                    Caption = x.Name,
                    ParentKey = x.ParentGameTypeId,
                    ParentCaption = x.ParentGameType?.Name
                });

            return result.ToList();
        }

        private GameTypeModel MapEntityToModel(GameType entity)
        {
            return new GameTypeModel
            {
                Id = entity.Id,
                Name = entity.Name,
                ParentGameTypeId = entity.ParentGameTypeId
            };
        }
    }
}