﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog23.Models
{
    public class Blog
    {
        public int Id { get; set; }
        
        public string BlogUserId { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage ="The {0} of the blog must be at least {2} and at most {1} characters in length.", MinimumLength = 2)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(500, ErrorMessage = "The {0} of the blog must be at least {2} and at most {1} characters in length.", MinimumLength = 2)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created on: ")]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Updated on: ")]
        public DateTime? Updated { get; set; }

        [Display(Name = "Blog Image: ")]
        public byte[] ImageData { get; set; }

        [Display(Name = "Image Type: ")]
        public string ContentType { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        //Navigation Properties
        public virtual BlogUser BlogUser { get; set; }
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();
    }
}