using System.ComponentModel.DataAnnotations;

namespace QuestionsWeb.ViewModels;

public class LoginViewModel
{
    [Required]
    [StringLength(80, MinimumLength = 3)]
    [Display(Name = "Имя пользователя")]
    public string Login { get; set; }

    [Required]
    [Display(Name = "Пароль")]
    [DataType(DataType.Password)]
    [StringLength(80, MinimumLength = 3)]
    public string Password { get; set; }

    [Display(Name = "Запомнить")]
    public bool RememberMe { get; set; }

    public string? ReturnUrl { get; set; }
}
