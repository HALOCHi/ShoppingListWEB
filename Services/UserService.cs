using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using ShoppingListWEB.Models;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger<UserService> _logger;

    public UserService(UserManager<ApplicationUser> userManager, ILogger<UserService> logger)
    {
        _userManager = userManager;
        _logger = logger;
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
        _logger.LogInformation("Проверка существования пользователя: Username={Username}, Email={Email}", username, email);
        var userByUsername = await _userManager.FindByNameAsync(username);
        var userByEmail = await _userManager.FindByEmailAsync(email);
        bool exists = userByUsername != null || userByEmail != null;
        _logger.LogInformation("Пользователь существует: {Exists}", exists);
        return exists;
    }
}