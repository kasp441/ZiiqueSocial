using Domain;
using Domain.Dto;

namespace Service;

public interface IPostService
{
    public Task<PaginationFilter<Post>> GetPosts(PaginationFilterDRO pagination);
    public Task<Post> CreatePost(PostDto post);
    public Task<Post> UpdatePost(Post post);
    public Task DeletePost(Guid id);
}