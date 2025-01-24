using DependencyInjectionDemo.IServices;

namespace DependencyInjectionDemo.Services;

public class SqlDataService : IDataService
{
    public string GetData()
    {
        return "I am a SQL";
    }
}