using Domain;
using Repo;

namespace Service;

public class PostService : IPostService
{
    private readonly IPostRepo _postRepo;
    public PostService(IPostRepo postRepo)
    {
        _postRepo = postRepo;
    }
    
    public async Task<PaginationFilter<Post>> GetPosts(PaginationFilterDRO pagination)
    {
        return await _postRepo.GetPosts(pagination);
    }

    public async Task<Post> CreatePost(Post post)
    {
        await _postRepo.CreatePost(post);
        return post;
    }

    public async Task<Post> UpdatePost(Post post)
    {
        await _postRepo.UpdatePost(post);
        return post;
    }

    public async Task DeletePost(Guid id)
    {
        await _postRepo.DeletePost(id);
    }
}