using App.Domain.Entities;
using App.Domain.Interfaces.Repositories;
using App.Domain.Interfaces.Services;

namespace App.Application.Services;

public class AnoUserService : IAnoUserService
{
    private IAnoUserRepository _anoUserRepo;
    private ICartRepository _cartRepo;

    public AnoUserService(IAnoUserRepository anoUserRepo, ICartRepository cartRepo)
    {
        _anoUserRepo = anoUserRepo;
        _cartRepo = cartRepo;
    }

    public async Task<CartEntity?> GetCart(int anoUserId)
    {
        var anoUser = await _anoUserRepo.GetByIdAsync(anoUserId);

        if (anoUser == null)
        {
            return null;
        }

        var cart = await _cartRepo.GetByIdAsync(anoUser.CartId);

        return cart;
    }

    public async Task<AnoUserEntity> CreateAnoUser(CartEntity cart)
    {
        var newAnoUser = new AnoUserEntity()
        {
            Cart = cart
        };

        var anoUser = await _anoUserRepo.Add(newAnoUser);

        await _anoUserRepo.SaveChangesAsync();

        return anoUser;
    }

    public async Task<bool> DeleteAnoUser(string? anoUserId)
    {
        if (anoUserId == null)
        {
            return false;
        }

        var anoUser = await _anoUserRepo.GetByIdAsync(int.Parse(anoUserId));

        if (anoUser == null)
        {
            return false;
        }

        await _anoUserRepo.Remove(anoUser);
        await _anoUserRepo.SaveChangesAsync();

        return true;
    }

    public async Task<AnoUserEntity?> GetAnoUserById(int anoUserId)
    {
        return await _anoUserRepo.GetByIdAsync(anoUserId);
    }
}