using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repo;

public class PostRepo : IPostRepo
{
    private readonly RepoContext _context;
    public PostRepo(RepoContext context)
    {
        _context = context;
    }
    
    public async Task<PaginationFilter<Post>> GetPosts(PaginationFilterDRO pagination)
    {
        //TODO: Check after if the user is allowed too see the posts
        var posts = await _context.Posts
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync();
        var totalRecords = _context.Posts.Count();
        return new PaginationFilter<Post>
        {
            Items = posts,
            PageNumber = pagination.PageNumber,
            PageSize = pagination.PageSize,
            TotalPages = (int)Math.Ceiling((double)totalRecords / pagination.PageSize),
            TotalRecords = totalRecords
        };
    }

    public async Task<PaginationFilter<Post>> GetPostsByUser(Guid userId, PaginationFilterDRO pagination)
    {
        var posts = await _context.Posts
            .Where(p => p.ProfileId == userId)
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync();
        var totalRecords = _context.Posts.Count(p => p.ProfileId == userId);
        return new PaginationFilter<Post>
        {
            Items = posts,
            PageNumber = pagination.PageNumber,
            PageSize = pagination.PageSize,
            TotalPages = (int)Math.Ceiling((double)totalRecords / pagination.PageSize),
            TotalRecords = totalRecords
        };
    }

    public async Task CreatePost(Post post)
    {
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePost(Post post)
    {
        _context.Posts.Update(post);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePost(Guid id)
    {
        var post = await _context.Posts.FindAsync(id) ?? throw new KeyNotFoundException("Could not find the post you are trying to delete");
        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
    }
}