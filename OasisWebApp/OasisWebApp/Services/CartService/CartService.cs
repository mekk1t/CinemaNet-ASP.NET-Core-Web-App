using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OasisWebApp.Database.Entities;
using OasisWebApp.DTOs;
using OasisWebApp.Services.CartService.Repository;
using OasisWebApp.Services.TicketService;
using System.Threading.Tasks;

namespace OasisWebApp.Services.CartService
{
    public class CartService
    {
        private readonly CartRepository cartRepository;
        private readonly IMapper mapper;
        public CartService(
            CartRepository cartRepository,
            IMapper mapper)
        {
            this.cartRepository = cartRepository;
            this.mapper = mapper;
        }

        public async Task<CartDto> Checkout(string cartId)
        {
            var cart = await cartRepository.Checkout(cartId);
            var cartDto = mapper.Map<CartDto>(cart);
            return cartDto;
        }

        public async Task DeleteCartAsync(string cartId)
        {
            await cartRepository.DeleteCartAsync(cartId);
        }
        public async Task<CartDto> GetCartAsync(string userId)
        {
            var cart = await cartRepository.GetCartAsync(userId);
            var cartDto = mapper.Map<CartDto>(cart);
            return cartDto;
        }

        public async Task<CartDto> CreateCartAsync(string userId)
        {
            var cart = await cartRepository.CreateCartAsync(userId);
            var cartDto = mapper.Map<CartDto>(cart);
            return cartDto;
        }

        public async Task RemoveItemsAsync(string cartItemId, string cartId)
        {
            await cartRepository.RemoveItemAsync(cartItemId, cartId);
        }

        public async Task AddItemToCartAsync(
            int ticketId,
            string userId)
        {

            await cartRepository.AddItemToCartAsync(ticketId, userId);            
        }
        public async Task<string> GetCartIdAsync(string userId)
        {
            var cartId = await cartRepository.GetCartIdAsync(userId);
            return cartId;
        }


    }
}
