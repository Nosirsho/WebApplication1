using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.DataAccess.Configurations;

public class PlaceCategoryConfiguration: IEntityTypeConfiguration<PlaceCategoty>
{
    public void Configure(EntityTypeBuilder<PlaceCategoty> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Places)
            .WithOne(x => x.PlaceCategoty)
            .HasForeignKey(x=>x.PlaceCategoryId);
    }
}