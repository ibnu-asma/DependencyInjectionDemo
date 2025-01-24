using DependencyInjectionDemo.IServices;

namespace DependencyInjectionDemo.Services;

public class SingletonService : ISingletonService
{
    private readonly Guid _serviceId;
    private readonly DateTime _createdAt;
    public SingletonService()
    {
        _serviceId = Guid.NewGuid();
        _createdAt = DateTime.Now;
        
    }

    public string Name => nameof(SingletonService);


    public string SayHello()
    {
        return $"Hello! I am {Name},  My id is {_serviceId}. I was created at {_createdAt}";
    }
}