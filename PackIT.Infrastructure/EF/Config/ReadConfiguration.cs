using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PackIT.Application.DTO;
using PackIT.Infrastructure.EF.Models;

namespace PackIT.Infrastructure.EF.Config
{
    internal sealed class ReadConfiguration : IEntityTypeConfiguration<PackingListReadModel>, IEntityTypeConfiguration<PackingItemReadModel>
    {
        public void Configure(EntityTypeBuilder<PackingListReadModel> builder)
        {
            builder.ToTable("PackingList");
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Localization)
                .HasConversion(x => x.ToString(), x => LocalizationReadModel.Create(x));

            builder
                .HasMany(x => x.Items)
                .WithOne(pi => pi.PackingList);
        }

        public void Configure(EntityTypeBuilder<PackingItemReadModel> builder)
        {
            builder.ToTable("PackingItems");
        }
    }
}
