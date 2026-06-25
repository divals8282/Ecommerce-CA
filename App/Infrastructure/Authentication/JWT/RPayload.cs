using App.Application.Enums.JWT;

namespace App.Infrastructure.Authentication.JWT;

public record RJwtPayload(
    int NameIdentifier,
    string Name,
    string Role,
    ETokenType AuthenticationMethod
);