namespace App.Domain.Entities;


public class CardEntity
{
    public int Id { get; set; }
    public IdentityEntity Identity = null!;
    public List<ProductEntity> Products = null!;
    public DateTime CreatedAt;
}