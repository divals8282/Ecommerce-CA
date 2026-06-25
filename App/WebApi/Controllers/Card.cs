using App.Application.Services;
using App.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.WebApi.Controllers;

[ApiController]
public class CardController : ControllerBase {

    private CardService _cardService;

    public CardController (CardService cardService) {
        _cardService = cardService;
    }

    [HttpGet("card")]
    public async Task<IResult> GetCard() 
    {
        var identityId = Request.Cookies["identity"];

        if(identityId != null) {
            var Card = await _cardService.GetCard(int.Parse(identityId));

            return Results.Json(new { status = true, Card }, statusCode: 200);
        }

        return Results.Json(new { status = false }, statusCode: 200);
    }

    [HttpPut("/card/add/{productId}")]
    public async Task<IResult> AddProduct() 
    {
        return Results.Json(new {  }, statusCode: 200);
    }

    [HttpDelete("/card/product/{productId}")]
    public async Task<IResult> DeleteProduct()
    {
        return Results.Json(new {  }, statusCode: 200);
    }

    [HttpDelete("/card")]
    public async Task<IResult> Card(ProductEntity product)
    {
        return Results.Json(new {  }, statusCode: 200);
    }
}