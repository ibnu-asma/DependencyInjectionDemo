using DependencyInjectionDemo.IServices;

namespace DependencyInjectionDemo.Services;


public class DemoService : IDemoService
{
    private readonly Guid _servieId;
    private readonly DateTime _createdAt;

    public DemoService()
    {
        _servieId = Guid.NewGuid();
        _createdAt = DateTime.Now;
    }
    public string SayHello()
    {
        return $"Hello! My id is {_servieId}. I was created at {_createdAt}";
    }
}