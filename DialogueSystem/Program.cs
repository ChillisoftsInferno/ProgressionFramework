using DialogueSystem.Domain;
using DialogueSystem.Interfaces;
using DialogueSystem.Services;
using GlobalHelpers.Helpers;
using GlobalHelpers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DialogueSystem;

public static class Program
{
    public static void Main()
    {
        IHost host = Host
            .CreateDefaultBuilder()
            .ConfigureServices(InjectDependencies())
            .Build();

        var game = host.Services.GetRequiredService<IStartGame>();

        game.Launch();
    }

    private static Action<IServiceCollection> InjectDependencies()
    {
        return services =>
        {
            services.AddSingleton<IJsonParser, JsonParser>();
            services.AddSingleton<IPlayerController, PlayerController>();
            services.AddSingleton<IDialogueManager, DialogueManager>();
            services.AddSingleton<IDialogueMenu, DialogueMenu>();
            services.AddSingleton<IStartGame, StartGame>();
        };
    }
}