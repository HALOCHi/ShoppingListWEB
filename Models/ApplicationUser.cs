using Microsoft.AspNetCore.Identity;
using ServiceStack.DataAnnotations;

namespace ShoppingListWEB.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Unique]
        public string UserName { get; set; }
    }
}