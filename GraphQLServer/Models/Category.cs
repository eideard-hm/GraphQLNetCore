namespace GraphQLServer.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Publication> Publications { get; set; } = null!;
    }
}