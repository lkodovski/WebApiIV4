﻿using System.ComponentModel.DataAnnotations;

namespace ApiMovies.Models
{
    //testiranje na branch - ovi
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
