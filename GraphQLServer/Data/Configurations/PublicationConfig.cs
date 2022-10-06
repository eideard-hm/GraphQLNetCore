using GraphQLServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQLServer.Data.Configurations
{
    public class PublicationConfig : IEntityTypeConfiguration<Publication>
    {
        public void Configure(EntityTypeBuilder<Publication> builder)
        {
            builder.ToTable(nameof(Publication), "blog");
            builder.HasKey(pu => pu.Id);

            builder.Property(pu => pu.Title)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(pu => pu.Description)
                .IsRequired()
                .HasMaxLength(5000);

            builder.Property(pu => pu.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(pu => pu.Status)
                .HasDefaultValue(PublicationStatus.REVISION);
        }
    }
}
