using GenericDataStructures.Interfaces;
using GenericDataStructures.Presenters;
using GenericDataStructures.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GenericDataStructures;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        IHost host = Host
            .CreateDefaultBuilder()
            .ConfigureServices(InjectDependencies())
            .Build();
        
        var app = host.Services.GetRequiredService<IDataStructureGenerator>();

        app.Launch();
    }

    private static Action<IServiceCollection> InjectDependencies()
    {
        return services =>
        {
            services.AddSingleton<IDataStructurePresenter, DataStructurePresenter>();
            services.AddSingleton<IDataStructureGenerator, DataStructureGenerator>();
        };
    }
}