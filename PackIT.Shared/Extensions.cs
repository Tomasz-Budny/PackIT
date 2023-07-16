using Microsoft.Extensions.DependencyInjection;
using PackIT.Shared.Commands;
using PackIT.SharedAbstractions.Commands;

namespace PackIT.Shared
{
    public static class Extensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();
            return services;
        }
    }
}
