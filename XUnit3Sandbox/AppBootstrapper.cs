using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Linq;
using System.Reflection;

namespace XUnit3Sandbox.UI;
public class AppBootstrapper
{
    public void RegisterAll(IServiceCollection services, Assembly? assembly = default)
    {
        RegisterServices(services, assembly);
        RegisterViews(services, assembly);
        RegisterViewModels(services, assembly);
    }

    public virtual void RegisterViews(IServiceCollection services, Assembly? assembly = default)
    {
        var viewTypes = (assembly ?? GetType().Assembly)
            .GetTypes()
            .Where(x => x.Name.EndsWith("View") || x.Name.EndsWith("Window"));

        foreach (var viewType in viewTypes)
            services.AddTransient(viewType);
    }

    public virtual void RegisterViewModels(IServiceCollection services, Assembly? assembly = default)
    {

        var vmTypes = (assembly ?? GetType().Assembly)
            .GetTypes()
            .Where(x => x.Name.EndsWith("ViewModel"))
            .Where(x => !x.IsAbstract && !x.IsInterface);

        foreach (var vmType in vmTypes)
            services.TryAddTransient(vmType);
    }

    public virtual void RegisterServices(IServiceCollection services, Assembly? assembly = default)
    {
    }
}