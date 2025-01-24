using DependencyInjectionDemo.IServices;

namespace DependencyInjectionDemo.Services;

public class MongoDataService : IDataService
{
    public string GetData()
    {
        return "I am a Mongo";
    }
}

