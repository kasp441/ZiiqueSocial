using Domain;

namespace Service;

public interface IPostService
{
    public Task<PaginationFilter<Post>> GetPosts(PaginationFilterDRO pagination);
    public Task<Post> CreatePost(Post post);
    public Task<Post> UpdatePost(Post post);
    public Task DeletePost(Guid id);
}