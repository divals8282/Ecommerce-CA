using App.Domain.Enums;

namespace App.Application.DTOS.Auth;

public class GetUserResponseDTO
{
    public string UserName { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public RoleEnum Role { get; set; } = RoleEnum.CLIENT;
}