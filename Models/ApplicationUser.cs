using Microsoft.AspNetCore.Identity;

namespace ShoppingListWEB.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string UserName { get; set; }
    }
}