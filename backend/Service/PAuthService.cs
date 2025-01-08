using Domain;
using Repo;

namespace Service;

public class PAuthService : IPAuthService
{
    private readonly IPAuthRepo _profileAuthRepository;

    public PAuthService(IPAuthRepo profileAuthRepository)
    {
        _profileAuthRepository = profileAuthRepository;
    }

    public async Task<bool> CheckIfExistPa(Guid authId)
    {
        return await _profileAuthRepository.CheckIfExistPa(authId);
    }
}