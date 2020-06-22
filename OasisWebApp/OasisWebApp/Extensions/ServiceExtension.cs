using Microsoft.Extensions.DependencyInjection;
using OasisWebApp.CinemaService.Services;
using OasisWebApp.CinemaService.Services.Interface;
using OasisWebApp.Services.AccountService.Service;
using OasisWebApp.Services.FilmService.Services;
using OasisWebApp.Services.FilmService.Services.Interface;
using OasisWebApp.Services.SessionService.Services;
using OasisWebApp.Services.SessionService.Services.Interface;

namespace OasisWebApp.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(
            this IServiceCollection services)
        {
            services.AddScoped<ICinemaService, CinemasService>();
            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<SignService>();
            services.AddScoped<UserService>();

            return services;
        }
    }
}
