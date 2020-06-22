using AutoMapper;
using OasisWebApp.DTOs;
using OasisWebApp.Database.Entities;
using System;
using Microsoft.AspNetCore.Identity;

namespace OasisWebApp.Mapper
{
    public class OasisWebAppProfile : Profile
    {
        public OasisWebAppProfile()
        {
            CreateMap<Cinema, CinemaDto>()
                .ForMember(dto => dto.Films, opt => opt.MapFrom(src => src.FilmsLink));
            CreateMap<CinemaFilm, CinemaDto>();
            CreateMap<Film, FilmDto>()
                .AfterMap((src, dto) =>
                {
                    dto.RunningTime_Hours = Math.Round(src.RunningTime / 60.0, 1).ToString() + " ч" ;
                    dto.ReleaseDate = src.ReleaseDate.ToLongDateString();
                });
            CreateMap<CinemaFilm, FilmDto>()
                .ForMember(dto => dto.FilmId, opt => opt.MapFrom(src => src.FilmId))
                .ForMember(dto => dto.Title, opt => opt.MapFrom(src => src.Film.Title));

            CreateMap<Session, SessionDto>();
            CreateMap<Ticket, TicketDto>();
            CreateMap<Cart, CartDto>();


            CreateMap<Address, AddressDto>()
                .AfterMap((src, dto) =>
                {
                    dto.Address = src.Street + ", " + src.House;
                });

            CreateMap<CinemaDto, Cinema>()
                .AfterMap((s, d) =>
            {
                foreach (var film in d.FilmsLink)
                    film.CinemaId = s.CinemaId;
            });

            CreateMap<FilmDto, Film>();

            CreateMap<UserDto, IdentityUser>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(src => src.Username));
            CreateMap<IdentityUser, UserDto>()
                .ForMember(d => d.Username, opt => opt.MapFrom(src => src.UserName));

        }
    }
}
