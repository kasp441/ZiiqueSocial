using System.ComponentModel.DataAnnotations;
using Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace ZiiqueSocialBackend.Controller;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;
    private readonly ILogger<PostController> _logger;
    
    public PostController(IPostService postService, ILogger<PostController> logger)
    {
        _postService = postService;
        _logger = logger;
    }
    
    /// <summary>
    /// Endpoint to get all posts with pagination support
    /// </summary>
    /// <param name="pagination"></param>
    /// <returns>List with all available post</returns>
    [HttpGet]
    [ProducesResponseType(typeof(PaginationFilter<Post>), 200)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetPosts(PaginationFilterDRO pagination)
    {
        try
        {
            PaginationFilter<Post> posts = await _postService.GetPosts(pagination);
            return Ok(posts);
        } catch (Exception e)
        {
            _logger.LogError(e, "Error getting posts");
            return StatusCode(500, "It seems we cant quite get the posts right now, please try again later.");
        }
    }
    
    /// <summary>
    /// Endpoint to create a new post to ZiiqueSocial
    /// </summary>
    /// <param name="post"></param>
    /// <returns>Same post given if it was created successful</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Post), 200)]
    [ProducesResponseType(typeof(BadRequest), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> CreatePost(Post post)
    {
        try
        {
            await _postService.CreatePost(post);
            return Ok(post);
        }
        catch (ValidationException)
        {
            return BadRequest("The post you are trying to create is not valid");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error creating post");
            return StatusCode(500, "It seems we cant quite create the post right now, please try again later.");
        }
    }
    
    /// <summary>
    /// Endpoint to change the content of a post
    /// </summary>
    /// <param name="post"></param>
    /// <returns>Same post given if it was created successful</returns>
    [HttpPut]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(BadRequest), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> UpdatePost(Post post)
    {
        try
        {
            await _postService.UpdatePost(post);
            return Ok(post);
        }
        catch (ValidationException)
        {
            return BadRequest("You are trying to update the post with invalid data");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error updating post");
            return StatusCode(500, "It seems we cant quite update the post right now, please try again later.");
        }
    }
    
    /// <summary>
    /// Endpoint to remove one of your posts from ZiiqueSocial
    /// </summary>
    /// <param name="postId"></param>
    /// <returns></returns>
    [HttpDelete("{postId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(BadRequest), 404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> DeletePost(Guid postId)
    {
        try
        {
            await _postService.DeletePost(postId);
            return Ok();   
        } catch (KeyNotFoundException)
        {
            return BadRequest("The post you are trying to delete does not exist");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error deleting post");
            return StatusCode(500, "It seems we cant quite delete the post right now, please try again later.");
        }
    }
}