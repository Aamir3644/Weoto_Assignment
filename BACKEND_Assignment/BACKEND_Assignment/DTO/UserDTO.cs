using System.ComponentModel.DataAnnotations;

namespace BACKEND_Assignment.DTO
{
    public class UserDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
