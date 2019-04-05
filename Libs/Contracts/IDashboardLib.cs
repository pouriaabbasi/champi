using champi.Models.Dashboard;

namespace champi.Libs.Contracts
{
    public interface IDashboardLib
    {
        StatisticsModel GetStatistics();
    }
}