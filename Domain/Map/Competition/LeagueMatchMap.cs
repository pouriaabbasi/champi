using champi.Domain.Entity.Competition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace champi.Domain.Map.Competition
{
    public class LeagueMatchMap : IEntityTypeConfiguration<LeagueMatch>
    {
        public void Configure(EntityTypeBuilder<LeagueMatch> builder)
        {
            builder
                .HasOne(x => x.League)
                .WithMany(x => x.LeagueMatches)
                .HasForeignKey(x => x.LeagueId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(x => x.FirstTeam)
                .WithMany(x => x.LeagueMatchesFirstTeam)
                .HasForeignKey(x => x.FirstTeamId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(x => x.SecondTeam)
                .WithMany(x => x.LeagueMatchesSecondTeam)
                .HasForeignKey(x => x.SecondTeamId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(x => x.WinnerTeam)
                .WithMany(x => x.LeagueMatchesWinnerTeam)
                .HasForeignKey(x => x.WinnerTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .ToTable("LeagueMatch", "Competition");
        }
    }
}