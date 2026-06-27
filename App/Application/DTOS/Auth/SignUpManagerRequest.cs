using System.ComponentModel.DataAnnotations;

namespace App.Application.DTOS.Auth;

public class SignUpManagerRequestDTO
{
    [Required]
    [MinLength(3)]
    [MaxLength(24)]
    public string UserName { get; set; } = null!;

    [Required]
    [MinLength(3)]
    [MaxLength(24)]
    public string Name { get; set; } = null!;

    [Required]
    [MinLength(3)]
    [MaxLength(24)]
    public string LastName { get; set; } = null!;

    [Required]
    [MinLength(3)]
    [MaxLength(24)]
    public string Password { get; set; } = null!;

    [Required]
    [MinLength(3)]
    [MaxLength(24)]
    public string SuperSecret { get; set; } = null!;
}