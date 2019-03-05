using champi.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace champi.Domain.Map
{
    public class CompetitionTeamMap : IEntityTypeConfiguration<CompetitionTeam>
    {
        public void Configure(EntityTypeBuilder<CompetitionTeam> builder)
        {
            builder
                .HasOne(x => x.Competition)
                .WithMany(x => x.CompetitionTeams)
                .HasForeignKey(x => x.CompetitionId);
            builder
                .HasOne(x => x.Team)
                .WithMany(x => x.CompetitionTeams)
                .HasForeignKey(x => x.TeamId);

            builder
                .ToTable("CompetitionTeam", "Competition");
        }
    }
}