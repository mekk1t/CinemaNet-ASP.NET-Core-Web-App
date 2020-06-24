using AutoMapper;
using OasisWebApp.DTOs;
using OasisWebApp.Database.Entities;
using System;

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

            CreateMap<Ticket, TicketDto>();
            CreateMap<TicketDto, Ticket>();

            CreateMap<CartItem, CartItemDto>();
            CreateMap<CartItemDto, CartItem>();


            CreateMap<Cart, CartDto>()
                .AfterMap((src, dto) =>
                {
                    foreach (var cartItem in src.CartItems)
                    {
                        dto.Total = dto.Total + cartItem.Ticket.Price;
                    }
                });

            CreateMap<Order, OrderDto>();
        }
    }
}
