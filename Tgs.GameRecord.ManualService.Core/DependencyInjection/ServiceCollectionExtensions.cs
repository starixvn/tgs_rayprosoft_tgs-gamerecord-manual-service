using System.Reflection;
using Tgs.GameRounds.Schedule.Client;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddManualServiceCore(
        this IServiceCollection services,
        Action<GameRoundsScheduleClinetOptions, IServiceProvider> gameRoundsScheduleClinetOptions)
        => services
        .RegisterAllServiceUtilityTypes(
            Assembly.GetExecutingAssembly(),
            ServiceLifetime.Transient)
        .AddGameRoundsScheduleClinet(gameRoundsScheduleClinetOptions);
}
