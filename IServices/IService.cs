namespace DependencyInjectionDemo.IServices;

public interface IService
{
    string Name { get; }
    string SayHello();
}