﻿using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Domain;
using Domain.Dto;
using Microsoft.AspNetCore.Authorization;
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
    public async Task<IActionResult> GetPosts([FromQuery]PaginationFilterDRO pagination)
    {
        try
        {
            var authId = Guid.Empty;
            if (!string.IsNullOrEmpty(Request.Headers["Authorization"].ToString()))
            {
                var authHeader = Request.Headers["Authorization"].ToString();
                var token = authHeader.Substring("Bearer ".Length).Trim();
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);
                authId = Guid.Parse(jwtToken.Claims.First(claim => claim.Type == "sub").Value);
            }
            PaginationFilter<Post> posts = await _postService.GetPosts(pagination, authId);
            return Ok(posts);
        } catch (Exception e)
        {
            _logger.LogError(e, "Error getting posts");
            return StatusCode(500, "It seems we cant quite get the posts right now, please try again later.");
        }
    }
    
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetPostsByUser(Guid userId, [FromQuery]PaginationFilterDRO pagination)
    {
        try
        {
            var authId = Guid.Empty;
            if (!string.IsNullOrEmpty(Request.Headers["Authorization"].ToString()))
            {
                var authHeader = Request.Headers["Authorization"].ToString();
                var token = authHeader.Substring("Bearer ".Length).Trim();
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);
                authId = Guid.Parse(jwtToken.Claims.First(claim => claim.Type == "sub").Value);
            }
            PaginationFilter<Post> posts = await _postService.GetPostsByUser(userId, authId, pagination);
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
    [Authorize]
    [HttpPost]
    [ProducesResponseType(typeof(Post), 200)]
    [ProducesResponseType(typeof(BadRequest), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> CreatePost(PostDto post)
    {
        try
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            var token = authHeader.Substring("Bearer ".Length).Trim();
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var authId = Guid.Parse(jwtToken.Claims.First(claim => claim.Type == "sub").Value);
            await _postService.CreatePost(post, authId);
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
    /// Endpoint to remove one of your posts from ZiiqueSocial
    /// </summary>
    /// <param name="postId"></param>
    /// <returns></returns>
    [Authorize]
    [HttpDelete("{postId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(BadRequest), 404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> DeletePost(Guid postId)
    {
        try
        {
            Post post = await _postService.GetPost(postId);
            var authHeader = Request.Headers["Authorization"].ToString();
            var token = authHeader.Substring("Bearer ".Length).Trim();
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var authId = Guid.Parse(jwtToken.Claims.First(claim => claim.Type == "sub").Value);
            if (post.ProfileId != authId)
            {
                return BadRequest("You are not allowed to delete this post");
            }
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