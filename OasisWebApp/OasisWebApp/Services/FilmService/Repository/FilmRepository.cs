using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using OasisWebApp.Database;
using OasisWebApp.Database.Entities;
using OasisWebApp.Services.FilmService.Repository.Filters;
using OasisWebApp.Services.FilmService.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OasisWebApp.Services.FilmService.Repository
{
    public class FilmRepository : IFilmRepository
    {
        private readonly OasisCinemaDbContext dbContext;
        private readonly ILogger<FilmRepository> logger;

        public FilmRepository(
            ILogger<FilmRepository> logger,
            OasisCinemaDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public Task<Film> CreateAsync(Film film)
        {
            EntityEntry<Film> result = dbContext.Films.Add(film);
            return Task.FromResult(result.Entity);
        }

        public Task DeleteAsync(int FilmId)
        {
            try
            {
                dbContext.Films.SingleOrDefault(f => f.FilmId == FilmId);
            }
            catch (ArgumentNullException)
            {
                throw new Exception("Такого фильма не существует");
            }
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Film>> FindAsync(FilmFilter filter = null)
        {
            var films = dbContext.Films
                                  .AsNoTracking()
                                  .Include(f => f.Sessions)
                                  .AsEnumerable();
            return Task.FromResult(films);
        }

        public Task<Film> GetAsync(int FilmId, FilmFilter filter = null)
        {
            var film = dbContext.Films.Include(f => f.Sessions)
                                        .ThenInclude(f => f.Cinema)
                                      .Single(f => f.FilmId == FilmId);
            return Task.FromResult(film);
        }

        public Task<Film> UpdateAsync(Film entity)
        {
            throw new NotImplementedException();
        }
    }
}
