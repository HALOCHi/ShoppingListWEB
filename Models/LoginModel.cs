using System.ComponentModel.DataAnnotations;

namespace ShoppingListWEB.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Имя пользователя обязательно")]
        public string Username { get; set; }

        //[Required]
        //public string Email { get; set; }

        [Required(ErrorMessage = "Пароль обязателен")]
        public string Password { get; set; }
    }
}
