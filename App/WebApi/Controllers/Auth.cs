using App.Application.DTOS.Auth;
using App.Application.Services;
using App.Domain.Entities;
using App.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.WebApi.Controllers;

[ApiController]
public class AuthController : ControllerBase {

    private readonly UserService _userService;

    public AuthController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("/auth/sign-up")]    
    public async Task<IResult> SignUp([FromBody] SignUpRequestDTO request)
    {
        var newUser = new UserEntity(){
            UserName = request.UserName,
            LastName = request.LastName,
            Name = request.Name,
            Password = request.Password,
            Role = request.Role,
            Checkouts = new List<CheckoutEntity>(),
            RefreshToken = ""
        };

        var result = await _userService.RegisterUser(newUser);


        if(result) {
            return Results.Json(new { status = true, user = newUser }, statusCode: 200);
        }

        return Results.Json(new { status = false }, statusCode: 200);
    }

    [HttpPost("/auth/sign-in")]
    public async Task<IResult> SignIn([FromBody] SignInRequestDTO request)
    {
        
        return Results.Json(new {  }, statusCode: 200);
    }

    [HttpPost("/auth/sign-up/content-manager/{SUPER-SECRET}")]
    public async Task<IResult> SignUpContentManager() {

        return Results.Json(new {}, statusCode: 200);
    }

    [HttpGet("/auth/get-user")]
    public async Task<IResult> GetUser(ProductEntity product)
    {
        return Results.Json(new {  }, statusCode: 200);
    }
}