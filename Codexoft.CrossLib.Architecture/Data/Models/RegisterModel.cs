using Codexoft.CrossLib.Architecture.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Codexoft.CrossLib.Architecture.Data.Models
{
    public class RegisterModel : BaseValidation
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
