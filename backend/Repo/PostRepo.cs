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
    
    public async Task<PaginationFilter<Post>> GetPosts(PaginationFilterDRO pagination, Guid userId)
    {
        var follows = await _context.Follows
            .Where(f => f.follows == userId)
            .Select(f => f.profile)
            .ToListAsync();

        
        var postsQuery = _context.Posts.Where(p =>
            p.Visibility == Visibility.Public ||
            (p.Visibility == Visibility.Followers && follows.Contains(p.ProfileId)) ||
            p.ProfileId == userId);

        
        var posts = await postsQuery
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync();

        
        var totalRecords = await postsQuery.CountAsync();

        return new PaginationFilter<Post>
        {
            Items = posts,
            PageNumber = pagination.PageNumber,
            PageSize = pagination.PageSize,
            TotalPages = (int)Math.Ceiling((double)totalRecords / pagination.PageSize),
            TotalRecords = totalRecords
        };
    }

    public async Task<PaginationFilter<Post>> GetPostsByUser(Guid userId, Guid askingUser, PaginationFilterDRO pagination)
    {
        var follows = await _context.Follows
            .Where(f => f.follows == userId)
            .Select(f => f.profile)
            .ToListAsync();
        
        var postsQuery = _context.Posts.Where(p =>
            (p.Visibility == Visibility.Public ||
            (p.Visibility == Visibility.Followers && follows.Contains(p.ProfileId)) ||
            p.ProfileId == askingUser) && p.ProfileId == userId);
        
        var posts = await postsQuery
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync();
        
        var totalRecords = await postsQuery.CountAsync();
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
    
    public async Task<Post> GetPost(Guid id)
    {
        return await _context.Posts.FindAsync(id) ?? throw new KeyNotFoundException("Could not find the post you are looking for");
    }

    public async Task DeletePost(Guid id)
    {
        var post = await _context.Posts.FindAsync(id) ?? throw new KeyNotFoundException("Could not find the post you are trying to delete");
        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
    }
}