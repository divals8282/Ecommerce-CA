using App.Domain.Entities;
using App.Domain.Interfaces.Repositories;
using App.Infrastructure.Presistence;

namespace App.Infrastructure.Repositories;


public class AnoUserRepository : IAnoUserRepository
{

    private readonly AppDbContext _db;

    public AnoUserRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<AnoUserEntity?> GetByIdAsync(int id)
    {
        return await _db.Identites.FindAsync(id);
    }

    public async Task<AnoUserEntity> Add(AnoUserEntity anoUser)
    {
        await _db.Identites.AddAsync(anoUser);

        return anoUser;
    }

    public async Task<bool> Remove(AnoUserEntity anoUser)
    {
        _db.Identites.Remove(anoUser);

        return true;
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}