using System.ComponentModel.DataAnnotations;

namespace ApiMovies.Models.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [MaxLength(100, ErrorMessage ="The max characters is 100")]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
