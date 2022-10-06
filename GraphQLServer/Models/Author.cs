namespace GraphQLServer.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public decimal Salary { get; set; }
        public int PublicationId { get; set; }
        public ICollection<Publication> Publications { get; set; } = null!;
    }
}
