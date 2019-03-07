using champi.Domain.Entity.Competition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace champi.Domain.Map.Competition
{
    public class LeagueMap : IEntityTypeConfiguration<League>
    {
        public void Configure(EntityTypeBuilder<League> builder)
        {
            builder
                .HasOne(x => x.CompetitionStep)
                .WithMany(x => x.Leagues)
                .HasForeignKey(x => x.CompetitionStepId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .ToTable("League", "Competition");
        }
    }
}