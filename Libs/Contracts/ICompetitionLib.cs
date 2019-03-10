using System.Collections.Generic;
using champi.Models.Competition;

namespace champi.Libs.Contracts
{
    public interface ICompetitionLib
    {
         List<CompetitionModel> GetCompetitions();
    }
}