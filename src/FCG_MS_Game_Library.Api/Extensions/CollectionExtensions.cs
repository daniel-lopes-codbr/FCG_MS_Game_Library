using UserRegistrationAndGameLibrary.Application.Interfaces;
using UserRegistrationAndGameLibrary.Application.Services;
using UserRegistrationAndGameLibrary.Domain.Interfaces;
using UserRegistrationAndGameLibrary.Infra.Repository;

namespace UserRegistrationAndGameLibrary.Api.Extensions
{
    public static class CollectionExtensions
    {
        public static IServiceCollection UseCollectionExtensions(this IServiceCollection services)
        {
            services.AddScoped<IUserAuthorizationRepository, UserAuthorizationRepository>();
            services.AddScoped<IGameLibraryRepository, GameLibraryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            
            services.AddScoped<IUserAuthorizationService, UserAuthorizationService>();
            services.AddScoped<IGameLibraryService, GameLibraryService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IUserService, UserService>();
            
            return services;
        }
    }
}
