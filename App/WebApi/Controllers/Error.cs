using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class ErrorController : ControllerBase
{
    [HttpGet("/error")]
    [HttpPost("/error")]
    [HttpPut("/error")]
    [HttpDelete("/error")]
    public IResult Handle()
    {
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
        var exception = context?.Error;

        return exception switch
        {
            _ => Results.Json(new { status = false, message = "Internal server error" }, statusCode: 500)
        };
    }
}