using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingListWEB.Models;

public class AccountController : Controller
{
    private readonly IUserService _userService;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(IUserService userService, SignInManager<ApplicationUser> signInManager)
    {
        _userService = userService;
        _signInManager = signInManager;
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
            return new JsonResult(new { success = false, error = "Пользователь с таким именем или email уже существует." });
        }

        var result = await _userService.RegisterUserAsync(model);

        if (result.Succeeded)
        {
            return new JsonResult(new { success = true, redirectUrl = "/login.html" });
        }
        else
        {
            return new JsonResult(new { success = false, errors = result.Errors.Select(e => e.Description).ToList() });
        }
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (!ModelState.IsValid)
        {
            return new JsonResult(new { success = false, errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList() });
        }

        var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            return new JsonResult(new { success = true, redirectUrl = "/list.html" });
        }
        else
        {
            return new JsonResult(new { success = false, error = "Аккаунт не найден" });
        }
    }
}