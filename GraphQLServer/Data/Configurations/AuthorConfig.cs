using GraphQLServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQLServer.Data.Configurations
{
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable(nameof(Author), "blog");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.LastName)
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(x => x.Email)
               .IsRequired()
               .HasMaxLength(200);

            builder.Property(x => x.Salary)
               .HasColumnType("decimal(18,3)")
               .HasDefaultValue<decimal>(0M);

            // relationshipts configurations
            builder.HasMany(au => au.Publications)
                .WithOne(au => au.Author)
                .HasForeignKey(au => au.AuthorId)
                .OnDelete(DeleteBehavior.Cascade); ;
        }
    }
}
