using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire.")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [Range(0.01, 1_000_000, ErrorMessage = "Le prix doit être entre 0,01 et 1 000 000.")]
        public double Price { get; set; }
    }
}
