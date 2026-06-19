using App.Domain.Enums;

namespace App.Domain.Entities;


public class UserEntity {
    public int Id { get; set; }
    required public string Name;
    required public string LastName;
    required public string RefreshToken;

    required public string Password;

    required public List<CheckoutEntity> Checkouts;

    required public RoleEnum Role;

    public bool CheckPassword(string password) {
        if(password == Password) {
            return true;
        }
        return false;
    }
}