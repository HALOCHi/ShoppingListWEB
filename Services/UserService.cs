using Microsoft.AspNetCore.Identity;
using ShoppingListWEB.Models;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> RegisterUserAsync(string username, string email, string password)
    {
        var user = new ApplicationUser { UserName = username, Email = email };
        return await _userManager.CreateAsync(user, password);
    }
}