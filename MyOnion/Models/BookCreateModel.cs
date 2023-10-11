using System.ComponentModel.DataAnnotations;

namespace MyOnion.Models
{
    public class BookCreateModel
    {
        [Required]
        [MaxLength(200)]
        public string? Title { get; set; }
        [Range(0, int.MaxValue)]
        public int Price { get; set; }
    }
}
