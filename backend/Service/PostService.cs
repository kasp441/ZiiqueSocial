using Domain;
using Domain.Dto;
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
    
    public async Task<PaginationFilter<Post>> GetPostsByUser(Guid userId, PaginationFilterDRO pagination)
    {
        return await _postRepo.GetPostsByUser(userId, pagination);
    }

    public async Task<Post> CreatePost(PostDto postDto)
    {
        Post post = new Post()
        {
            Id = new Guid(),
            Title = postDto.Title,
            Content = postDto.Content,
            CreatedAt = postDto.CreatedAt,
            ProfileId = postDto.ProfileId
        };
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