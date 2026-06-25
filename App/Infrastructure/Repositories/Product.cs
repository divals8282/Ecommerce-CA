using App.Domain.Entities;
using App.Infrastructure.Presistence;

namespace App.Infrastructure.Repositories;


public class ProductRepository {

     private readonly AppDbContext _db;

    public ProductRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<ProductEntity?> GetByIdAsync(int id)
    {
        return await _db.Products.FindAsync(id);
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}