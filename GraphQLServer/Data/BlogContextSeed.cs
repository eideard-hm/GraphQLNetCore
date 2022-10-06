using GraphQLServer.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLServer.Data;
public class BlogContextSeed
{
    public static async Task SeedAsync(BlogContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            await context.Database.OpenConnectionAsync();

            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT blog.Categoria ON");
            if (!context.Categories.Any())
            {

                var categorias = new List<Category>()
                {
                    new Category(){Id=1, Name="Graphql"},
                    new Category(){Id=2, Name="Desarrollo Web"},
                    new Category(){Id=3, Name="Restful APIs"},
                    new Category(){Id=4, Name="NET Core"},
                    new Category(){Id=5, Name="Blazor"}
                };

                await context.Categories.AddRangeAsync(categorias);
                await context.SaveChangesAsync();

            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT blog.Categoria OFF");

            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT blog.Autor ON");
            if (!context.Authors.Any())
            {

                var autores = new List<Author>()
                {
                    new Author(){ Id=1, Name="Javier",LastName="González",Email="javierglez@correo.com"},
                    new Author(){ Id=2, Name="Janeth",LastName="Rosales",Email="jarosales@correo.com"},
                    new Author(){ Id=3, Name="Israel",LastName="Jimenez",Email="isjimenez@correo.com"},
                };

                await context.Authors.AddRangeAsync(autores);
                await context.SaveChangesAsync();

            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT blog.Autor OFF");


            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT blog.Publicacion ON");
            if (!context.Publications.Any())
            {

                var publicaciones = new List<Publication>()
                {
                    new Publication()
                    {
                         Id=1,
                         AuthorId=1,
                         CategoryId=1,
                         Status= PublicationStatus.ACTIVA,
                         ImageUrl="https://picsum.photos/id/1/200/300",
                         Description=@"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                                      Phasellus metus enim, ornare nec ante nec, tincidunt 
                                      tristique sapien. Aenean tincidunt sapien at tincidunt congue. 
                                      Nullam vitae posuere nunc. Mauris velit dolor, ornare eu 
                                      pulvinar venenatis, ultrices sit amet est. Integer dapibus 
                                      orci sed mattis fringilla. ",
                         Rating=5,
                         Title="Mi primera publicación"
                    },
                    new Publication()
                    {
                         Id=2,
                         AuthorId=2,
                         CategoryId=2,
                         Status= PublicationStatus.ACTIVA,
                         ImageUrl="https://picsum.photos/id/10/200/300",
                         Description=@"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                                      Phasellus metus enim, ornare nec ante nec, tincidunt 
                                      tristique sapien. Aenean tincidunt sapien at tincidunt congue. 
                                      Nullam vitae posuere nunc. Mauris velit dolor, ornare eu 
                                      pulvinar venenatis, ultrices sit amet est. Integer dapibus 
                                      orci sed mattis fringilla. ",
                         Rating=4,
                         Title="Mi segunda publicación"
                    }
                };

                await context.Publications.AddRangeAsync(publicaciones);
                await context.SaveChangesAsync();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT blog.Publicacion OFF");

            await context.Database.CloseConnectionAsync();

        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<BlogContextSeed>();
            logger.LogError(ex, "Ocurrió un error durante la inicialización de información de relleno a la Base de Datos.");
        }


    }
}