using Microsoft.AspNetCore.Identity;
using ShoppingListWEB.Models;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> RegisterUserAsync(RegisterModel model)
    {
        var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
        try
        {
            var result = await _userManager.CreateAsync(user, model.Password);
            return IdentityResult.Success;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating user: {ex.Message}");
            return IdentityResult.Failed(new[] { new IdentityError { Description = ex.Message } });
        }
    }

    public async Task<bool> UserExistsAsync(string username, string email)
    {
        var userByUsername = await _userManager.FindByNameAsync(username);
        var userByEmail = await _userManager.FindByEmailAsync(email);
        return userByUsername != null || userByEmail != null;
    }
}