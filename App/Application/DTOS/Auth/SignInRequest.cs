using System.ComponentModel.DataAnnotations;

namespace App.Application.DTOS.Auth;

public class SignInRequestDTO {
    [Required]
    [MinLength(3)]
    [MaxLength(24)]
    public string UserName {get; set;} = null!;

    [Required]
    [MinLength(3)]
    [MaxLength(24)]
    public string Password {get; set;} = null!;
}