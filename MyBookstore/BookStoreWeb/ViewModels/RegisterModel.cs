using System.ComponentModel.DataAnnotations;

namespace BookStoreWeb.ViewModels
{
    public class RegisterModel
    {
       
        public string? RoleName { get; set; }

        [Required(ErrorMessage ="Не указано имя")]
        public string UserName { get; set; }

        [Phone]
        [Required(ErrorMessage ="Не указан № телефона")]
        public string Phone { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
    }
}
