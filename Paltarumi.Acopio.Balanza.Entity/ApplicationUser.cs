using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public class ApplicationUser : IdentityUser<int>
    {
        [Required]
        [MaxLength(100)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string? LastName { get; set; }

        [Required]
        public bool Activo { get; set; }
    }
}
