using System.ComponentModel.DataAnnotations;

namespace QuestionsWeb.ViewModels;

public class RegisterUserViewModel //: IValidatableObject
{
    [Required(ErrorMessage = "Имя пользователя является обязательным")]
    [MaxLength(80)]
    [Display(Name = "Имя пользователя")]
    public string UserName { get; set; }

    [Required]
    [Display(Name = "Пароль")]
    [DataType(DataType.Password)]
    [MaxLength(100, ErrorMessage = "Длина пароля не должна превышать 100 символов")]
    public string Password { get; set; }

    [Required]
    [Display(Name = "Подтверждение пароля")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password))]
    [MaxLength(100, ErrorMessage = "Длина пароля не должна превышать 100 символов")]
    public string PasswordConfirm { get; set; }

    //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    //{
    //    throw new NotImplementedException();
    //}
}
