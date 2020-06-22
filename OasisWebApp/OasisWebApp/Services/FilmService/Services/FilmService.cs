using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OasisWebApp.Database.Entities;
using OasisWebApp.DTOs;
using OasisWebApp.Services.FilmService.Repository.Filters;
using OasisWebApp.Services.FilmService.Repository.Interface;
using OasisWebApp.Services.FilmService.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OasisWebApp.Services.FilmService.Services
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository filmRepository;
        private readonly ILogger<FilmService> logger;
        private readonly IMapper mapper;
        public FilmService(
            [FromServices] IFilmRepository filmRepository,
            [FromServices] ILogger<FilmService> logger,
            [FromServices] IMapper mapper)
        {
            this.filmRepository = filmRepository;
            this.logger = logger;
            this.mapper = mapper;
        }
        public async Task<FilmDto> CreateAsync(FilmDto film)
        { 
            var result = await filmRepository.CreateAsync(mapper.Map<Film>(film));
            var resultDto = mapper.Map<FilmDto>(result);
            return resultDto;
        }

        public async Task DeleteAsync(int id)
        {
            await filmRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<FilmDto>> FindAsync(FilmFilter filter = null)
        {
            var result = await filmRepository.FindAsync();
            var resultDto = mapper.Map<IEnumerable<FilmDto>>(result);
            return resultDto;
        }

        public async Task<FilmDto> GetAsync(int id, FilmFilter filter = null)
        {
            var result = await filmRepository.GetAsync(id);
            var resultDto = mapper.Map<FilmDto>(result);
            return resultDto;
        }
    }
}
