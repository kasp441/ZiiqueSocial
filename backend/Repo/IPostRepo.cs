﻿using Domain;

namespace Repo;

public interface IPostRepo
{
    public Task<PaginationFilter<Post>> GetPosts(PaginationFilterDRO pagination, Guid userId);
    public Task<PaginationFilter<Post>> GetPostsByUser(Guid userId, Guid askingUser, PaginationFilterDRO pagination);
    public Task<Post> GetPost(Guid id);
    public Task CreatePost(Post post);
    public Task UpdatePost(Post post);
    public Task DeletePost(Guid id);
}