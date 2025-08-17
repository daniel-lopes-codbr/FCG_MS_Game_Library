using UserRegistrationAndGameLibrary.Application.Dtos;

namespace UserRegistrationAndGameLibrary.Application.Interfaces;
public interface IUserAuthorizationService
{
    public Task<string> GetToken(AuthorizationTokenDto request);
    Task<string> AddPermissionByUserAsync(UserAuthorizationDto request);
    Task<string> UpdatePermissionByUserAsync(UserAuthorizationDto request);
}
