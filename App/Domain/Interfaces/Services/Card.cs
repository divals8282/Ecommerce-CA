using App.Domain.Entities;

namespace App.Domain.Interfaces.Services;

public interface ICartService
{
    public Task<CartEntity?> GetCart(string? anoUserId);

    public Task<int?> AddProduct(string? anoUserId, int productId);
    public Task<bool> DeleteProduct(string? anoUserId, int productId);
    public Task<bool> DeleteInactiveCartsAsync();

    public Task<bool> DeleteCart(string? anoUserId);
}