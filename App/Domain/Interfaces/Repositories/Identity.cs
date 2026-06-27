using App.Domain.Entities;

namespace App.Domain.Interfaces.Repositories;

public interface IAnoUserRepository
{
    public Task<AnoUserEntity?> GetByIdAsync(int id);
    public Task<AnoUserEntity> Add(AnoUserEntity anoUser);
    public Task<bool> Remove(AnoUserEntity anoUser);
    public Task SaveChangesAsync();

}