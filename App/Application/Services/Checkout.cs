using App.Domain.Entities;
using App.Infrastructure.Repositories;

namespace App.Application.Services;


public class CheckoutService
{
    private IdentityRepository _identityRepo;

    private CardRepository _cardRepo;

    private CheckoutRepository _checkoutRepo;
    private UserService _userService;

    public CheckoutService(CardRepository cardRepo, IdentityRepository identityRepo, ProductRepository productRepo, UserService userService, CheckoutRepository checkoutRepo)
    {
        _cardRepo = cardRepo;
        _identityRepo = identityRepo;
        _userService = userService;
        _checkoutRepo = checkoutRepo;
    }


    public async Task<bool> ArchivateCard(int identityId)
    {
        var identity = await _identityRepo.GetByIdAsync(identityId);

        if (identity == null)
        {
            return false;
        }

        var card = await _cardRepo.GetByIdentityId(identity.Id);

        if (card == null)
        {
            return false;
        }

        if (card.Products.Count() == 0)
        {
            return false;
        }

        var user = await _userService.GetCurrentUser();

        if (user == null)
        {

            return false;
        }

        var newCheckout = new CheckoutEntity()
        {
            User = user,
            Products = card.Products,
        };

        await _checkoutRepo.AddNewCheckout(newCheckout);


        return true;
    }
}