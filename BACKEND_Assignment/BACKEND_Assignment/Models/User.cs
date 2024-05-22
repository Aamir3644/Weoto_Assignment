using System.ComponentModel.DataAnnotations;

namespace BACKEND_Assignment.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        [Phone]
        public string MobileNumber { get; set; }
    }
}
