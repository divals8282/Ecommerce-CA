using App.Application.DTOS.Auth;
using App.Domain.Entities;

namespace App.Domains.Interfaces.Services;

public interface IProductService
{
    public Task<List<ProductEntity>> List(int limit, int offset);
    public Task<ProductEntity?> GetProductById(int productId);
    public Task<ProductEntity?> Add(ProductRequestDTO product);
    public Task<bool> Delete(int productId);
    public Task<bool> Edit(int productId, ProductRequestDTO productDTO);
}