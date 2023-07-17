using Microsoft.Extensions.DependencyInjection;
using PackIT.SharedAbstractions.Queries;
using System.Reflection;

namespace PackIT.Shared.Queries
{
    public static class Extensions
    {
        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();

            services.AddSingleton<IQueryDispatcher, InMemoryQueryDispatcher>();

            // W tym miejscu korzystamy z nugeta Scrutor, jest pomocne przy rejestrowaniu dependencji - doczytać o nim
            services.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            return services;
        }
    }
}
