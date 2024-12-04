using Microsoft.AspNetCore.Identity;
using ShoppingListWEB.Models;

public interface IUserService
{
    Task<IdentityResult> RegisterUserAsync(string username, string email, string password);
}