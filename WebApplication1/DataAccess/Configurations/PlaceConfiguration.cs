using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.DataAccess.Configurations;

public class PlaceConfiguration: IEntityTypeConfiguration<Place>
{
    public void Configure(EntityTypeBuilder<Place> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(p => p.PlaceCategoty)
            .WithMany(p => p.Places)
            .HasForeignKey(p=>p.PlaceCategoryId);
    }
}