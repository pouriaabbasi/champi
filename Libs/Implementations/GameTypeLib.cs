using System.Collections.Generic;
using System.Linq;
using champi.Context.Repository;
using champi.Domain.Entity.Competition;
using champi.Libs.Contracts;
using champi.Models.GameType;

namespace champi.Libs.Implementations
{
    public class GameTypeLib : IGameTypeLib
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<GameType> _gameTypeRepo;

        public GameTypeLib(
            IUnitOfWork unitOfWork,
            IRepository<GameType> gameTypeRepo
        )
        {
            _unitOfWork = unitOfWork;
            _gameTypeRepo = gameTypeRepo;
        }

        public List<GameTypeModel> GetGameTypes()
        {
            var result =
                _gameTypeRepo
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
    }
}