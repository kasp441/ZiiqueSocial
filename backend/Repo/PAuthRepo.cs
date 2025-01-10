using Microsoft.EntityFrameworkCore;

namespace Repo;

public class PAuthRepo : IPAuthRepo
{
    private readonly RepoContext _context;

    public PAuthRepo(RepoContext context)
    {
        _context = context;
    }

    public async Task<bool> CheckIfExistPa(Guid authId)
    {
        return await _context.Profiles.AnyAsync(pa => pa.Guid == authId);
    }
}