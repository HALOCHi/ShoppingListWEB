using System.ComponentModel.DataAnnotations;

namespace ShoppingListWEB.Models
{
    public class RegisterModel
    {

        [Required(ErrorMessage = "Поле \"Имя пользователя\" обязательно для заполнения.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Поле \"Email\" обязательно для заполнения.")]
        [EmailAddress(ErrorMessage = "Неверный формат Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле \"Пароль\" обязательно для заполнения.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Пароль должен содержать не менее 8 символов.")]
        public string Password { get; set; }
    }
}