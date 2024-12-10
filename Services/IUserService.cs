using Microsoft.AspNetCore.Identity;
using ShoppingListWEB.Models;

public interface IUserService
{
    Task<IdentityResult> RegisterUserAsync(RegisterModel model);

    Task<bool> UserExistsAsync(string username, string email);
}