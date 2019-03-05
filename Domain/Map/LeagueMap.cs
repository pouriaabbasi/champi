using champi.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace champi.Domain.Map
{
    public class LeagueMap : IEntityTypeConfiguration<League>
    {
        public void Configure(EntityTypeBuilder<League> builder)
        {
            builder
                .HasOne(x => x.CompetitionStep)
                .WithMany(x => x.Leagues)
                .HasForeignKey(x => x.CompetitionStepId);

            builder
                .ToTable("League", "Competition");
        }
    }
}