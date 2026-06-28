using App.Domain.Entities;

namespace App.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    public Task<UserEntity?> GetByIdAsync(int id);

    public Task<UserEntity?> GetByUserNameAsync(string userName);

    public Task AddAsync(UserEntity user);

    public Task SaveChangesAsync();

}