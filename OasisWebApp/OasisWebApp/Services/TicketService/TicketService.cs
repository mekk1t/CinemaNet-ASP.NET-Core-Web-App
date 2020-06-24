using AutoMapper;
using OasisWebApp.DTOs;
using OasisWebApp.Services.TicketService.Repository;
using System.Threading.Tasks;

namespace OasisWebApp.Services.TicketService
{
    public class TicketService
    {
        private readonly TicketRepository ticketRepository;
        private readonly IMapper mapper;

        public TicketService(
            IMapper mapper,
            TicketRepository ticketRepository)
        {
            this.mapper = mapper;
            this.ticketRepository = ticketRepository;
        }

        public async Task<TicketDto> GetTicketAsync(int ticketId)
        {
            var ticket = await ticketRepository.GetTicketAsync(ticketId);
            var ticketDto = mapper.Map<TicketDto>(ticket);
            return ticketDto;
        }

        public async Task UpdateTicketAsync(int ticketId, int orderId)
        {
            await ticketRepository.UpdateTicketAsync(ticketId, orderId);
        }


    }
}
