using champi.Domain.Entity.Competition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace champi.Domain.Map.Competition
{
    public class CompetitionStepMap : IEntityTypeConfiguration<CompetitionStep>
    {
        public void Configure(EntityTypeBuilder<CompetitionStep> builder)
        {
            builder
                .HasOne(x => x.Competition)
                .WithMany(x => x.CompetitionSteps)
                .HasForeignKey(x => x.CompetitionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .ToTable("CompetitionStep", "Competition");
        }
    }
}