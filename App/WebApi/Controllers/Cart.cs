using App.Application.DTOS.Cart;
using App.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.WebApi.Controllers;

[ApiController]
public class CartController : ControllerBase
{

    private readonly ICartService _cartService;
    private readonly IAnoUserService _anoUserService;

    public CartController(ICartService cartService, IAnoUserService anoUserService)
    {
        _cartService = cartService;
        _anoUserService = anoUserService;
    }

    [HttpGet("cart")]
    public async Task<IResult> GetCart()
    {
        var anoUserId = Request.Cookies["anoUser"];

        var cart = await _cartService.GetCart(anoUserId);

        if(cart == null)
        {
            Response.Cookies.Delete("anoUser");
        }

        return Results.Json(new GetCartResponseDTO
        {
            Status = cart != null,
            Data = cart?.Products?
                .Select(p => new GetCartResponseDTO.Products
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                })
                .ToList()
        }, statusCode: 200);
    }

    [HttpPut("/cart/add/{productId}")]
    public async Task<IResult> AddProduct(int productId)
    {
        var anoUserId = Request.Cookies["anoUser"];

        var possibleNewAnoUser = await _cartService.AddProduct(anoUserId, productId);

        if (anoUserId == null && possibleNewAnoUser != null)
        {
            var anoUserValue = possibleNewAnoUser.ToString();
            if (!string.IsNullOrEmpty(anoUserValue))
            {
                Response.Cookies.Append("anoUser", anoUserValue);
            }
        }

        return Results.Json(new { anoUser = anoUserId == null ? possibleNewAnoUser.ToString() : anoUserId }, statusCode: 200);
    }

    [HttpDelete("/cart/product/{productId}")]
    public async Task<IResult> DeleteProduct(int productId)
    {
        var anoUserId = Request.Cookies["anoUser"];

        var status = await _cartService.DeleteProduct(anoUserId, productId);

        return Results.Json(new { status }, statusCode: 200);
    }

    [HttpDelete("/cart")]
    public async Task<IResult> Cart()
    {
        var anoUserId = Request.Cookies["anoUser"];

        await _cartService.GetCart(anoUserId);
        await _anoUserService.DeleteAnoUser(anoUserId);

        Response.Cookies.Delete("anoUser");

        return Results.Json(new { status = true }, statusCode: 200);
    }
}