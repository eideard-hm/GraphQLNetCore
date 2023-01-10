using GraphQLServer.Data;
using GraphQLServer.Models;

namespace GraphQLServer.GraphQL.Publications
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Publication> RetrievePublications(BlogContext _context) => _context.Publications;

        [UseFirstOrDefault]
        [UseProjection]
        public IQueryable<Publication> GetPublicationById(BlogContext _context, int id) => _context.Publications.Where(p => p.Id == id);
    }
}
