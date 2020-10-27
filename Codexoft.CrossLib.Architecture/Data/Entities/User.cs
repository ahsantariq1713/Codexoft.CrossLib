using System.ComponentModel.DataAnnotations;

namespace Codexoft.CrossLib.Architecture.Data.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string HashPassword { get; private set; }

        [Required]
        public string Role { get; set; }

        public void SetHashPassword(string password)
        {
            HashPassword = BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
