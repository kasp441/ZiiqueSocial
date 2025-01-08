using Domain;
using Domain.Dto;

namespace Service;

public interface IPostService
{
    public Task<PaginationFilter<Post>> GetPosts(PaginationFilterDRO pagination, Guid userId);
    public Task<PaginationFilter<Post>> GetPostsByUser(Guid userId, PaginationFilterDRO pagination);
    public Task<Post> CreatePost(PostDto post, Guid userId);
    public Task<Post> UpdatePost(Post post);
    public Task DeletePost(Guid id);
}