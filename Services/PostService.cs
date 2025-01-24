using DependencyInjectionDemo.IServices;
using DependencyInjectionDemo.Models;
using Microsoft.OpenApi.Models;
namespace DependencyInjectionDemo.Services;

public class PostService : IPostService
{
    private readonly List<Post> _posts = new();
    public Task CreatePost(Post item)
    {
        _posts.Add(item);
        return Task.CompletedTask;
    }

    public Task DeletePost(int id)
    {
        var post = _posts.FirstOrDefault(p => p.Id == id);
        
        if (post is not null)
        {
            _posts.Remove(post);
        }

        return Task.CompletedTask;
    }

    public Task<List<Post>> GetAll()
    {
        return Task.FromResult(_posts);
    }

    public Task<Post?> GetPost(int id)
    {
        return Task.FromResult(_posts.FirstOrDefault(p => p.Id == id));
    }

    public Task<Post?> UpdatePost(int id, Post item)
    {
       var post = _posts.FirstOrDefault(p => p.Id  == id);
       if (post != null)
       {
        post.UserId = item.UserId;
        post.Title = item.Title;
        post.Description = item.Description;
       }

       return Task.FromResult(post);
    }
}