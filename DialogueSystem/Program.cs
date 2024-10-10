using DialogueSystem.Interfaces;
using DialogueSystem.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DialogueSystem;

public static class Program
{
    public static void Main()
    {
        IHost host = Host
            .CreateDefaultBuilder()
            .ConfigureServices(services => InjectDependencies())
            .Build();

        var game = host.Services.GetRequiredService<StartGame>();

        game.Launch();


        
        
    }

    private static IServiceCollection InjectDependencies()
    {
        IServiceCollection services = new ServiceCollection();
        
        services.AddSingleton<IApplication, Application>();
        services.AddSingleton<IJsonParser, JsonParser>();
        services.AddSingleton<IPlayerController, PlayerController>();
        services.AddSingleton<IDialogueManager, DialogueManager>();
        services.AddSingleton<IDialogueMenu, DialogueMenu>();
        services.AddSingleton<IStartGame, StartGame>();
        return services;
    }

}