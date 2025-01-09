using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repo;

public class FollowRepo : IFollowRepo
{
    private readonly RepoContext _context;
    
    public FollowRepo(RepoContext context)
    {
        _context = context;
    }   
    
    public async Task Follow(Guid followerId, Guid followingId)
    {
        Follows follow = new Follows
        {
            profile = followerId,
            follows = followingId
        };
        await _context.Follows.AddAsync(follow);
        await _context.SaveChangesAsync();
    }

    public Task Unfollow(Guid followerId, Guid followingId)
    {
        _context.Follows.Remove(_context.Follows.FirstOrDefault(f => f.profile == followerId && f.follows == followingId)); 
        return _context.SaveChangesAsync();
    }

    public async Task<List<Follows>> GetFollowers(Guid userId)
    {
        var follows = await _context.Follows.Where(f => f.profile == userId).ToListAsync();
        return follows;
    }
}