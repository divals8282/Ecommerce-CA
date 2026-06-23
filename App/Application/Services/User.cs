using App.Application.DTOS.Auth;
using App.Domain.Entities;
using App.Domain.Enums;
using App.Infrastructure.Repositories;
using App.Infrastructure.Services;
using App.Application.Authentication.JWT;

namespace App.Application.Services;

public class UserService {
    private readonly UserRepository _userRepo;
    private readonly AuthService _authService;

    public UserService(UserRepository userRepo, AuthService authService) {
        _userRepo = userRepo;
        _authService = authService;
    }

    public async Task<bool> SetNewRole(UserEntity user, RoleEnum role) {
        var u = await _userRepo.GetByIdAsync(user.Id);

        if(u != null) {
            u.Role = role;
            await _userRepo.SaveChangesAsync();

            return true;
        }

        return false;
    }

    public async Task<bool> RegisterUser(UserEntity user) {
        await _userRepo.AddAsync(user);
        await _userRepo.SaveChangesAsync();

        return true;
    }

    public async Task<object> Login(SignInRequestDTO user) {
        var u = await _userRepo.GetByFieldName("username", user.UserName);

        if(u == null) {
            return new { status = false, authTokens = new {} };
        }

        var isPasswordValid = await _authService.ComparePasswordAsync(u, user.Password);

        if(!isPasswordValid) {
            return new { status = false, authTokens = new {} };
        }

        var accessToken = await _authService.CreateTokenAsync(u, ETokenType.ACCESS);
        var refreshToken = await _authService.CreateTokenAsync(u, ETokenType.REFRESH);

        return new { status = true, authTokens = new {
            accessToken,
            refreshToken
        } };
    }
}