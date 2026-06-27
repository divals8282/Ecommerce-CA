using App.Domain.Entities;

namespace App.Domain.Interfaces.Services;

public interface IAnoUserService
{
    public Task<AnoUserEntity> CreateAnoUser(CartEntity cart);
    public Task<bool> DeleteAnoUser(string? anoUserId);
    public Task<CartEntity?> GetCart(int anoUserId);

    public Task<AnoUserEntity?> GetAnoUserById(int anoUserId);
}