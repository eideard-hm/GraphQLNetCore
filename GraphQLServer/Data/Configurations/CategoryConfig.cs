using GraphQLServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQLServer.Data.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category), "blog");
            builder.HasKey(ca => ca.Id);

            builder.Property(ca => ca.Name)
                .IsRequired()
                .HasMaxLength(200);

            // relationshipt configurations
            builder.HasMany(ca => ca.Publications)
                .WithOne(ca => ca.Category)
                .HasForeignKey(ca => ca.CategoryId)
                .OnDelete(DeleteBehavior.Cascade); ;
        }
    }
}
