using Microsoft.AspNetCore.Mvc;

namespace App.WebApi.Controllers;

[ApiController]
public class MainController : ControllerBase
{
    [HttpGet("/")]
    public async Task<IResult> Main()
    {
        return Results.Json(new { status = true }, statusCode: 200);
    }
}