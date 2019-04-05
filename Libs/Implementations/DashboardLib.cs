using champi.Libs.Contracts;
using champi.Models.Dashboard;
using champi.Domain.Entity.Security;
using champi.Domain.Entity.Competition;
using champi.Context.Repository;
using System.Linq;
using System.Collections.Generic;

namespace champi.Libs.Implementations
{
    public class DashboardLib : IDashboardLib
    {
        private readonly IRepository<User> userRepo;
        private readonly IRepository<Team> teamRepo;
        private readonly IRepository<GameType> gameTypeRepo;
        private readonly IRepository<League> leagueRepo;
        private readonly IRepository<Competition> competitionRepo;

        public DashboardLib(
            IRepository<User> userRepo,
            IRepository<Team> teamRepo,
            IRepository<GameType> gameTypeRepo,
            IRepository<League> leagueRepo,
            IRepository<Competition> competitionRepo
        )
        {
            this.userRepo = userRepo;
            this.teamRepo = teamRepo;
            this.gameTypeRepo = gameTypeRepo;
            this.leagueRepo = leagueRepo;
            this.competitionRepo = competitionRepo;
        }

        public StatisticsModel GetStatistics()
        {
            return new StatisticsModel
            {
                UserCount = GetUserCount(),
                TeamCount = GetTeamCount(),
                GameTypeCount = GetGameTypeCount(),
                LeagueCount = GetLeagueCount(),
                LeaguePerMonthData = GetLeaguePerMonthData(),
                LeagueByLeagueTypeData = GetLeagueByLeagueTypeData(),
            };
        }

        private int GetUserCount()
        {
            return userRepo.GetAll().Count();
        }
        private int GetTeamCount()
        {
            return teamRepo.GetAll().Count();
        }
        private int GetGameTypeCount()
        {
            return gameTypeRepo.GetAll().Count();
        }
        private int GetLeagueCount()
        {
            return leagueRepo.GetAll().Count();
        }
        private ChartModel GetLeaguePerMonthData()
        {
            return new ChartModel
            {
                Labels = new List<string> { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" },
                Datasets = new List<DataSetModel>{
                    CalcLeaguePerMonth()
                }
            };
        }
        private DataSetModel CalcLeaguePerMonth()
        {
            var result = new DataSetModel
            {
                Label = "# of Legaue/Month",
                BackgroundColor = "rgba(255, 99, 132, 0.4)",
                BorderColor = "rgba(255,99,132,.6)",
                BorderWidth = 1,
                Data = new List<int>()
            };
            for (int i = 1; i <= 12; i++)
            {
                result.Data.Add(competitionRepo.GetAll().Count(x => x.StartDate.Month == i));
            }
            return result;
        }
        private ChartModel GetLeagueByLeagueTypeData()
        {
            return new ChartModel
            {
                Labels = competitionRepo.GetAll().GroupBy(x => x.GameType.Name).OrderBy(x => x.Key).Select(x => x.Key).ToList(),
                Datasets = new List<DataSetModel>{
                      CalcLeagueByLeagueType()
                }
            };
        }
        private DataSetModel CalcLeagueByLeagueType()
        {
            var result = new DataSetModel
            {
                Label = "# of Game Type",
                BackgroundColor = "rgba(255, 99, 132, 0.4)",
                BorderColor = "rgba(255,99,132,.6)",
                BorderWidth = 1,
                Data = new List<int>()
            };
            var gameTypes = gameTypeRepo.GetAll().OrderBy(x => x.Name).Select(x => x.Id);
            foreach (var gameType in gameTypes)
            {
                result.Data.Add(competitionRepo.GetAll().Count(x => x.GameTypeId == gameType));
            }
            return result;
        }
    }
}
/*
{

    leagueByLeagueTypeData: {
      labels: ['JAN', 'FEB', 'MAR', 'APR', 'MAY', 'JUN', 'JUL', 'AUG', 'SEP', 'OCT', 'NOV', 'DEC'],
      datasets: [{
        label: '# of Leagues',
        data: [1, 2, 4, 6, 5, 4, 3, 8, 6, 4, 2, 1],
        backgroundColor: 'rgba(255, 99, 132, 0.4)',
        borderColor: 'rgba(255,99,132,.6)',
        borderWidth: 1
      }]
    }
  };
 */
