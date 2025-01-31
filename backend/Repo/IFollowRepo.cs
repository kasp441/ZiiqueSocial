﻿using Domain;

namespace Repo;

public interface IFollowRepo
{
    public Task Follow(Guid followerId, Guid followingId);
    public Task Unfollow(Guid followerId, Guid followingId);
    public Task<List<Follows>> GetFollowers(Guid userId);
}