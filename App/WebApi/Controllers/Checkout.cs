using App.Application.DTOS.Product;
using App.Domain.Enums;
using App.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.WebApi.Controllers;

[ApiController]
public class CheckoutControler : ControllerBase
{
    private ICheckoutService _checkoutService;

    public CheckoutControler(ICheckoutService checkoutService)
    {
        _checkoutService = checkoutService;
    }

    [HttpPut("/checkout")]
    [Authorize(Roles = nameof(ERole.CLIENT))]
    public async Task<IResult> Checkout()
    {
        var anoUserId = Request.Cookies["anoUser"];

        if (anoUserId != null)
        {
            var status = await _checkoutService.ArchivateCart(int.Parse(anoUserId));

            return Results.Json(new { status }, statusCode: 200);
        }

        return Results.Json(new { status = false }, statusCode: 200);
    }

    [HttpGet("/checkout/list")]
    [Authorize]
    public async Task<IResult> CheckoutList()
    {
        var anoUserId = Request.Cookies["anoUser"];

        if (anoUserId != null)
        {
            var list = await _checkoutService.List(int.Parse(anoUserId));

            if (list != null)
            {
                return Results.Json(list.Select(l => new CheckoutListResponseDTO
                {
                    User = new CheckoutListResponseDTO.UserDTO
                    {
                        UserName = l.User.UserName
                    },
                    Products = l.Products.Select(p => new CheckoutListResponseDTO.ProductDTO
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price
                    }).ToList()
                }), statusCode: 200);
            }

        }

        return Results.Json(new { status = false }, statusCode: 200);
    }
}