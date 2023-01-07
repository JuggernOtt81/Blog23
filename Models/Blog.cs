using System.ComponentModel.DataAnnotations;

namespace Blog23.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage ="The {0} of the blog must be at least {2} and at most {1} characters in length.", MinimumLength = 2)]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }
        public IFormFile Image { get; set; }
    }
}
