using Domain;

namespace Service;

public interface IPAuthService
{
    public Task<bool> CheckIfExistPa(Guid authId);
}