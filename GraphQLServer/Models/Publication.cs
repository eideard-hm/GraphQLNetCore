namespace GraphQLServer.Models
{
    public class Publication
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public PublicationStatus Status { get; set; }
        public int Rating { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
    }
}