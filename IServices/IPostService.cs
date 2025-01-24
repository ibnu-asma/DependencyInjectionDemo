
using DependencyInjectionDemo.Models; 
namespace DependencyInjectionDemo.IServices;
public interface IPostService
{
    Task<Post?> GetPost(int id);
    Task CreatePost(Post item);
    Task DeletePost(int id);

    Task<List<Post>> GetAll();
    Task<Post?> UpdatePost(int id, Post item);

}