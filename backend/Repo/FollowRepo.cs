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
        var profile = await _context.Profiles.FindAsync(followerId);
        var following = await _context.Profiles.FindAsync(followingId); 
        var follow = new Follows
        {
            profile = profile,
            follows = following
        };
        await _context.Follows.AddAsync(follow);
        await _context.SaveChangesAsync();
    }

    public Task Unfollow(Guid followerId, Guid followingId)
    {
        _context.Follows.Remove(_context.Follows.FirstOrDefault(f => f.profile.Guid == followerId && f.follows.Guid == followingId)); 
        return _context.SaveChangesAsync();
    }
}