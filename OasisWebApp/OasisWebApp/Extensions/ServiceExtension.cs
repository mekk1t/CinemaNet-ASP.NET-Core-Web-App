using Microsoft.Extensions.DependencyInjection;
using OasisWebApp.CinemaService.Services;
using OasisWebApp.CinemaService.Services.Interface;
using OasisWebApp.Services.AccountService;
using OasisWebApp.Services.CartService;
using OasisWebApp.Services.FilmService.Services;
using OasisWebApp.Services.FilmService.Services.Interface;
using OasisWebApp.Services.OrderService;
using OasisWebApp.Services.SessionService.Services;
using OasisWebApp.Services.SessionService.Services.Interface;
using OasisWebApp.Services.TicketService;

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
            services.AddScoped<AccountService>();
            services.AddScoped<CartService>();
            services.AddScoped<OrderService>();
            services.AddScoped<TicketService>();

            return services;
        }
    }
}
