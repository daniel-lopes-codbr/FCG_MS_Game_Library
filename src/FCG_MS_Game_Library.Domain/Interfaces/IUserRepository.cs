using UserRegistrationAndGameLibrary.Domain.Entities;

namespace UserRegistrationAndGameLibrary.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByEmailAsync(string email);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(User user);
    Task<List<User>> SearchUsersAsync(string? email, string? name);
}
