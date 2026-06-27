using System.ComponentModel.DataAnnotations;

namespace App.Application.DTOS.Product;

public class CheckoutListResponseDTO
{
    public class UserDTO
    {
        public required string UserName { get; set; }
    }
    public required UserDTO User { get; set; } = null!;

    public class ProductDTO
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required int Price { get; set; }
    }
    public required List<ProductDTO> Products { get; set; } = null!;
}