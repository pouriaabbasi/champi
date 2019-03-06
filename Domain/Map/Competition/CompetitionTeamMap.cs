using champi.Domain.Entity.Competition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace champi.Domain.Map.Competition
{
    public class CompetitionTeamMap : IEntityTypeConfiguration<CompetitionTeam>
    {
        public void Configure(EntityTypeBuilder<CompetitionTeam> builder)
        {
            builder
                .HasOne(x => x.Competition)
                .WithMany(x => x.CompetitionTeams)
                .HasForeignKey(x => x.CompetitionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(x => x.Team)
                .WithMany(x => x.CompetitionTeams)
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .ToTable("CompetitionTeam", "Competition");
        }
    }
}