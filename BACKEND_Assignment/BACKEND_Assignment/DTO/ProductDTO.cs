using System.ComponentModel.DataAnnotations;

namespace BACKEND_Assignment.DTO
{
    public class ProductDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
