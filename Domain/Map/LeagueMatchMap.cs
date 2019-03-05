using champi.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace champi.Domain.Map
{
    public class LeagueMatchMap : IEntityTypeConfiguration<LeagueMatch>
    {
        public void Configure(EntityTypeBuilder<LeagueMatch> builder)
        {
            builder
                .HasOne(x=>x.FirstTeam)
                .WithMany(x=>x.LeagueMatchesFirstTeam)
                .HasForeignKey(x=>x.FirstTeamId);
            builder
                .HasOne(x=>x.SecondTeam)
                .WithMany(x=>x.LeagueMatchesSecondTeam)
                .HasForeignKey(x=>x.SecondTeamId);
            builder
                .HasOne(x=>x.WinnerTeam)
                .WithMany(x=>x.LeagueMatchesWinnerTeam)
                .HasForeignKey(x=>x.WinnerTeamId);

            builder
                .ToTable("LeagueMatch", "Competition");
        }
    }
}