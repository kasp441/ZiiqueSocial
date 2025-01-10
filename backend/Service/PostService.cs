using Domain;
using Domain.Dto;
using Microsoft.Extensions.Logging;
using Repo;

namespace Service;

public class PostService : IPostService
{
    private readonly IPostRepo _postRepo;
    private readonly ILogger<PostService> _logger;
    public PostService(IPostRepo postRepo, ILogger<PostService> logger)
    {
        _postRepo = postRepo;
        _logger = logger;
    }   
    
    public async Task<PaginationFilter<Post>> GetPosts(PaginationFilterDRO pagination, Guid userId)
    {
        return await _postRepo.GetPosts(pagination, userId);
    }
    
    public async Task<PaginationFilter<Post>> GetPostsByUser(Guid userId, Guid askingUser, PaginationFilterDRO pagination)
    {
        return await _postRepo.GetPostsByUser(userId, askingUser, pagination);
    }
    
    public async Task<Post> GetPost(Guid id)
    {
        return await _postRepo.GetPost(id);
    }   

    public async Task<Post> CreatePost(PostDto postDto, Guid userId)
    {
        var post = new Post()
        {
            Id = Guid.NewGuid(),
            Title = postDto.Title,
            Content = postDto.Content,
            CreatedAt = postDto.CreatedAt,
            ProfileId = userId,
            Visibility = postDto.Visibility
        };
        await _postRepo.CreatePost(post);
        return post;
    }

    public async Task<Post> UpdatePost(Post post)
    {
        _logger.LogWarning("Updating post with id: {id}", post.Id); 
        await _postRepo.UpdatePost(post);
        return post;
    }

    public async Task DeletePost(Guid id)
    {
        await _postRepo.DeletePost(id);
    }
}