using Microsoft.Extensions.DependencyInjection;
using PackIT.Domain.Factories;
using PackIT.Domain.Policies;
using PackIT.Shared;

namespace PackIT.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            // tutaj poza dodaniem wszystkich commands do kontenera dependency injection dodajemy również 
            // Fabrykę
            services.AddCommands();
            services.AddSingleton<IPackingListFactory, PackingListFactory>();

            // Rejsetruję wszystkie policy jako singleton. Wykorzystuję narzędzie Scrutor
            services.Scan(b => b.FromAssemblies(typeof(IPackingItemsPolicy).Assembly)
                .AddClasses(c => c.AssignableTo<IPackingItemsPolicy>())
                .AsImplementedInterfaces()
                .WithSingletonLifetime());

            return services;
        }
    }
}
