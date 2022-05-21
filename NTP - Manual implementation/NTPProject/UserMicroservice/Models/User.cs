using System.ComponentModel.DataAnnotations;

namespace UserMicroservice.Models
{
    public class User
    {
        [Key]
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FName { get; set; }

        [Required]
        public string LName { get; set; }

        public string Email { get; set; }
    }
}
