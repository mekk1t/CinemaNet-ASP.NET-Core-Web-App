using Microsoft.Extensions.DependencyInjection;
using OasisWebApp.CinemaService.Repository;
using OasisWebApp.CinemaService.Repository.Interface;
using OasisWebApp.Services.CartService.Repository;
using OasisWebApp.Services.FilmService.Repository;
using OasisWebApp.Services.FilmService.Repository.Interface;
using OasisWebApp.Services.OrderService.Repository;
using OasisWebApp.Services.SessionService.Repository;
using OasisWebApp.Services.SessionService.Repository.Interface;
using OasisWebApp.Services.TicketService.Repository;

namespace OasisWebApp.Extensions
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepositories(
            this IServiceCollection services)
        {
            services.AddScoped<ICinemaRepository, CinemaRepository>();
            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<CartRepository>();
            services.AddScoped<OrderRepository>();
            services.AddScoped<TicketRepository>();
            return services;
        }
    }
}
