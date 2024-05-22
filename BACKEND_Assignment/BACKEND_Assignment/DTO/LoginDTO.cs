using System.ComponentModel.DataAnnotations;

namespace BACKEND_Assignment.DTO
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
