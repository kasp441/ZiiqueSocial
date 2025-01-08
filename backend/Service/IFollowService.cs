namespace Service;

public interface IFollowService
{
    public Task Follow(Guid followerId, Guid followingId);
    public Task Unfollow(Guid followerId, Guid followingId);
}