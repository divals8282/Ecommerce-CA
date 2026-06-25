namespace App.Domain.Entities;


public class IdentityEntity
{
    public int Id { get; set; }
    required public CardEntity Card;
}