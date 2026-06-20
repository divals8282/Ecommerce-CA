using App.Domain.Entities;
using App.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;

namespace App.Infrastructure.Services;


public class AuthService {
    private PasswordHasher<object> hasher = new PasswordHasher<object>();
    private readonly AuthRepository _repo;

    public AuthService(AuthRepository authRepository) {
        _repo = authRepository;
    }

    public async Task<bool> CheckPasswordValidity(UserEntity u, string cleanPassword) {
        var hashedPassword = hasher.HashPassword(new (), cleanPassword);
        var user = await _repo.GetByIdAsync(u.Id);

        if(user != null) {
            return user.Password == hashedPassword;
        }

        return false;
    }

    public async Task GenerateTokens(UserEntity user) {

    }

    public async Task CheckRefreshTokenValidity(string refreshToken) {

    }

    public async Task KillActualRefreshToken(UserEntity user) {

    }
}