﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog23.Models
{
    public class Post
    {
        public int Id { get; set; }
        
        public int BlogId { get; set; }
        
        public string AuthorId { get; set; }

        [Required]
        [StringLength(75, ErrorMessage = "The {0} of the post must be at least {2} and at most {1} characters in length.", MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} of the post must be at least {2} and at most {1} characters in length.", MinimumLength = 2)]
        public string Abstract { get; set; }

        [Required]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created on: ")]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Updated on: ")]
        public DateTime? Updated { get; set; }

        public bool IsReady { get; set; }

        public string Slug { get; set; }

        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
    }
}