using App.Domain.Entities;
using App.Domain.Interfaces.Repositories;
using App.Domain.Interfaces.Services;

namespace App.Application.Services;

public class CartService : ICartService
{
    private readonly IProductRepository _productRepo;
    private readonly IAnoUserService _anoUserService;

    private readonly ICartRepository _cartRepo;

    public CartService(IProductRepository productRepo, ICartRepository cartRepo, IAnoUserService anoUserService)
    {
        _productRepo = productRepo;
        _cartRepo = cartRepo;
        _anoUserService = anoUserService;
    }

    public async Task<CartEntity?> GetCart(string? anoUserId)
    {
        if (anoUserId == null)
        {
            return null;
        }

        var anoUserIdInt = int.TryParse(anoUserId, out var userId);

        if(anoUserIdInt == false)
        {
            return null;
        }

        var cart = await _anoUserService.GetCart(userId);
        

        return cart;
    }

    public async Task<int?> AddProduct(string? anoUserId, int productId)
    {
        var product = await _productRepo.GetByIdAsync(productId);

        if (product == null)
        {
            return null;
        }

        if (anoUserId == null)
        {
            var newCart = new CartEntity();
            var newAnoUser = await _anoUserService.CreateAnoUser(newCart);

            await _cartRepo.AddProduct(newCart.Id, product);
            await _cartRepo.SaveChangesAsync();

            return newAnoUser.Id;
        }

        var anoUserIdInt = int.TryParse(anoUserId, out var userId);

        if(anoUserIdInt == false)
        {
            return null;
        }

        var cart = await _cartRepo.GetByAnoUserId(userId);

        if (cart == null)
        {
            return null;
        }

        await _cartRepo.AddProduct(cart.Id, product);

        return userId;
    }

    public async Task<bool> DeleteProduct(string? anoUserId, int productId)
    {
        if (anoUserId == null)
        {
            return false;
        }
        
        var anoUserIdInt = int.TryParse(anoUserId, out var userId);

        if(anoUserIdInt == false)
        {
            return false;
        }

        var cart = await _cartRepo.GetByAnoUserId(userId);
        var product = await _productRepo.GetByIdAsync(productId);


        if (cart == null || product == null)
        {
            return false;
        }

        await _cartRepo.DeleteProduct(cart.Id, product);
        await _cartRepo.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteCart(string? anoUserId)
    {
        if (anoUserId == null)
        {
            return false;
        }

        var anoUserIdInt = int.TryParse(anoUserId, out var userId);

        if(anoUserIdInt == false)
        {
            return false;
        }

        var cart = await _cartRepo.GetByAnoUserId(userId);

        if (cart == null)
        {
            return false;
        }

        await _cartRepo.RemoveCart(cart);
        await _cartRepo.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteInactiveCartsAsync()
    {
        var inactiveCarts = await _cartRepo.GetInactiveCartsAsync();

        foreach (var cart in inactiveCarts)
        {
            await _cartRepo.RemoveCart(cart);
        }

        await _cartRepo.SaveChangesAsync();
        
        return true;
    }
}