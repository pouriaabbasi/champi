using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace champi.Domain.Map
{
    public class GameTypeMap : IEntityTypeConfiguration<GameType>
    {
        public void Configure(EntityTypeBuilder<GameType> builder)
        {
            builder
                .HasOne(x => x.ParentGameType)
                .WithMany(x => x.ChildGameTypes)
                .HasForeignKey(x => x.ParentGameTypeId);

            builder
                .Property(x => x.Name).HasMaxLength(100);

            builder
                .ToTable("GameType", "Competition");
        }
    }
}