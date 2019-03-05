using champi.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace champi.Domain.Map
{
    public class TeamMap : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder
                .Property(x => x.Name).HasMaxLength(200);
            builder
                .Property(x => x.AbbreviationName).HasMaxLength(10);
            builder
                .Property(x => x.Logo).HasMaxLength(100);

            builder
                .ToTable("Team", "Competition");
        }
    }
}