using Repo;

namespace Service;

public class FollowService : IFollowService
{
    private readonly IFollowRepo _followRepo;
    
    public FollowService(IFollowRepo followRepo)
    {
        _followRepo = followRepo;
    }   
    
    public async Task Follow(Guid followerId, Guid followingId)
    {
        await _followRepo.Follow(followerId, followingId);   
    }

    public async Task Unfollow(Guid followerId, Guid followingId)
    {
        await _followRepo.Unfollow(followerId, followingId);
    }

    public async Task<List<Guid>> GetFollowers(Guid userId)
    {
        var followers = await _followRepo.GetFollowers(userId);
        var followersIds = followers.Select(f => f.follows).ToList();
        return followersIds;
    }
}