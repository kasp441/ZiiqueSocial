using Domain;
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
        List<Follows> followers = await _followRepo.GetFollowers(userId);
        List<Guid> followersIds = new List<Guid>();
        foreach (Follows follow in followers)
        {
            followersIds.Add(follow.follows.Guid);
        }
        return followersIds;
    }
}