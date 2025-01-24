using DependencyInjectionDemo.IServices;
using Microsoft.VisualBasic;

namespace DependencyInjectionDemo.Services;

public class ScopedService : IScopedService
{
    private readonly ISingletonService _singletonService;
    private readonly ITransientService _transientService;
    
     private readonly Guid _serviceId;
    private readonly DateTime _createdAt;

    public ScopedService(ISingletonService singletonService, ITransientService transientService)
    {
        _singletonService = singletonService;
        _transientService = transientService;
         _serviceId = Guid.NewGuid();
        _createdAt = DateTime.Now;
    }

    public string Name => nameof(ScopedService);


    public string SayHello()
    {
        var scopedServiceMessage = $"Hello! I am {Name},  My id is {_serviceId}. I was created at {_createdAt}";
        var transientServiceMessage = $"{_transientService.SayHello()}, I am from {Name}";
        var singletonServiceMessage = $"{_singletonService.SayHello()}, I am from {Name}";

        return $"{scopedServiceMessage} {Environment.NewLine} {transientServiceMessage} {Environment.NewLine} {singletonServiceMessage}";
    }
}