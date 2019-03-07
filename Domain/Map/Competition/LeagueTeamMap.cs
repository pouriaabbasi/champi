using champi.Domain.Entity.Competition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace champi.Domain.Map.Competition
{
    public class LeagueTeamMap : IEntityTypeConfiguration<LeagueTeam>
    {
        public void Configure(EntityTypeBuilder<LeagueTeam> builder)
        {
            builder
                .HasOne(x => x.League)
                .WithMany(x => x.LeagueTeams)
                .HasForeignKey(x => x.LeagueId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(x => x.CompetitionTeam)
                .WithMany(x => x.LeagueTeams)
                .HasForeignKey(x => x.CompetitionTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .ToTable("LeagueTeam", "Competition");
        }
    }
}