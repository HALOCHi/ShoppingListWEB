using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingListWEB.Models;

public class AccountController : Controller
{
    private readonly IUserService _userService;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ILogger<AccountController> _logger;

    public AccountController(IUserService userService, SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger)
    {
        _userService = userService;
        _signInManager = signInManager;
        _logger = logger;
    }


    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (!ModelState.IsValid)
        {
            return new JsonResult(new { success = false, errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList() });
        }

        if (await _userService.UserExistsAsync(model.Username, model.Email))
        {
            return new JsonResult(new { success = false, error = "Пользователь с таким именем и email уже существует." });
        }

        var result = await _userService.RegisterUserAsync(model);

        if (result.Succeeded)
        {
            return Redirect("login.html");
        }
        else
        {
            return new JsonResult(new { success = false, errors = result.Errors.Select(e => e.Description).ToList() });
        }
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        _logger.LogInformation("Попытка входа: Username={Username}", model.Username);

        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Валидация модели не пройдена. Модель: {Model}", model);
            return BadRequest(ModelState);
        }

        var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

        if (result.Succeeded)
        {
            _logger.LogInformation("Успешный вход: Username={Username}", model.Username);
            return Ok();
        }
        else
        {
            _logger.LogWarning("Неудачный вход: Username={Username}", model.Username);
            return Unauthorized(new { success = false, error = "Неверный логин или пароль" });
        }
    }

}