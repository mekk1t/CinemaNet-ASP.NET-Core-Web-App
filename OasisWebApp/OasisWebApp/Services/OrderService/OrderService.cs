using AutoMapper;
using OasisWebApp.Database.Entities;
using OasisWebApp.DTOs;
using OasisWebApp.Services.OrderService.Repository;
using OasisWebApp.Services.TicketService.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OasisWebApp.Services.OrderService
{
    public class OrderService
    {
        private readonly TicketRepository ticketRepository;
        private readonly OrderRepository orderRepository;
        private readonly IMapper mapper;

        public OrderService(
            TicketRepository ticketRepository,
            OrderRepository orderRepository,
            IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
            this.ticketRepository = ticketRepository;
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersAsync(string userId)
        {
            var orders = await orderRepository.GetOrdersAsync(userId);
            var ordersDto = mapper.Map<IEnumerable<OrderDto>>(orders);
            return ordersDto;
        }

        public async Task CreateOrderAsync(string userId, ICollection<TicketDto> ticketsDto)
        {
            var tickets = mapper.Map<ICollection<Ticket>>(ticketsDto);
            var order = await orderRepository.CreateOrderAsync(userId, tickets);
            foreach (var ticket in tickets)
            {
                await ticketRepository.UpdateTicketAsync(ticket.TicketId, order.OrderId);
            }
        }


    }
}
