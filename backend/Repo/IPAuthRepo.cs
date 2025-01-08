using Domain;

namespace Repo;

public interface IPAuthRepo
{
    public Task<bool> CheckIfExistPa(Guid authId);
}