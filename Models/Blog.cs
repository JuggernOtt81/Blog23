namespace Blog23.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }
        public IFormFile Image { get; set; }
    }
}
