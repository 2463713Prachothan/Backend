using TimeTrack.API.Models;

namespace TimeTrack.API.Repository.IRepository;

public interface IUserRepository : IGenericRepository<UserEntity>
{
    Task<UserEntity> GetByEmailAsync(string email);
    Task<IEnumerable<UserEntity>> GetUsersByRoleAsync(string role);
    Task<IEnumerable<UserEntity>> GetUsersByDepartmentAsync(string department);
    Task<IEnumerable<UserEntity>> GetActiveUsersAsync();
    Task<bool> EmailExistsAsync(string email);
}