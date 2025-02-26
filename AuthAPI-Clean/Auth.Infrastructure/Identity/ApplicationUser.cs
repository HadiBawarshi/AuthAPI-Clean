using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Auth.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(254)]
        public string? Name { get; set; }

    }
}
