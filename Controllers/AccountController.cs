using Microsoft.AspNetCore.Mvc;
using ShoppingListWEB.Models;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterModel model) // Используем RegisterModel
    {
        if (ModelState.IsValid) // Важно! Проверяем валидацию модели
        {
            var result = await _userService.RegisterUserAsync(model.Username, model.Email, model.Password); // Передаем дополнительные параметры
            if (result.Succeeded)
            {
                return Ok(new { message = "Регистрация прошла успешно" });
            }
            return BadRequest(result.Errors.Select(e => e.Description));
        }
        return BadRequest(ModelState); // Возвращаем ошибки валидации
    }



}