using App.Domain.Entities;

namespace App.Domain.Interfaces.Services;

public interface ICheckoutService
{
    public Task<bool> ArchivateCart(int anoUserId);
    public Task<List<CheckoutEntity>?> List(int anoUserId);
}