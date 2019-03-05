using champi.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace champi.Domain.Map
{
    public class LeagueTeamMap : IEntityTypeConfiguration<LeagueTeam>
    {
        public void Configure(EntityTypeBuilder<LeagueTeam> builder)
        {
            builder
                .HasOne(x => x.League)
                .WithMany(x => x.LeagueTeams)
                .HasForeignKey(x => x.LeagueId);
            builder
                .HasOne(x => x.CompetitionTeam)
                .WithMany(x => x.LeagueTeams)
                .HasForeignKey(x => x.CompetitionTeamId);

            builder
                .ToTable("LeagueTeam", "Competition");
        }
    }
}