using Microsoft.Extensions.DependencyInjection;

[assembly: AssemblyFixture(typeof(CoreFixture))]
namespace XUnit3Sandbox.Tests;
public class CoreFixture
{
    public IServiceProvider Services { get; }

    public CoreFixture()
    {
        var bootstrapper = new TestBootstrapper();
        var services = new ServiceCollection();
        bootstrapper.RegisterAll(services, typeof(App).Assembly);
        Services = services.BuildServiceProvider();
    }

    public T GetRequiredService<T>() where T : class
    {
        return (T)Services.GetService(typeof(T))!;
    }
}
