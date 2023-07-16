using Microsoft.Extensions.DependencyInjection;
using PackIT.Shared.Commands;
using PackIT.SharedAbstractions.Commands;
using System.Reflection;

namespace PackIT.Shared
{
    public static class Extensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();

            services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();

            // W tym miejscu korzystamy z nugeta Scrutor, jest pomocne przy rejestrowaniu dependencji - doczytać o nim
            services.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            return services;
        }
    }
}
