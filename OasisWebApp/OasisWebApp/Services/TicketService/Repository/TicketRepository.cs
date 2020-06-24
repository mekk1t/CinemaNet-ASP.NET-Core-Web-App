using Microsoft.EntityFrameworkCore;
using OasisWebApp.Database;
using OasisWebApp.Database.Entities;
using System.Threading.Tasks;

namespace OasisWebApp.Services.TicketService.Repository
{
    public class TicketRepository
    {
        private readonly OasisCinemaDbContext dbContext;

        public TicketRepository(OasisCinemaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Ticket> GetTicketAsync (int ticketId)
        {
            var ticket = await dbContext.Tickets.SingleAsync(t => t.TicketId == ticketId);
            return ticket;
        }

        public async Task UpdateTicketAsync (int ticketId, int orderId)
        {
            var ticket = await dbContext.Tickets.SingleAsync(t => t.TicketId == ticketId);
            ticket.OrderId = orderId;
            dbContext.Tickets.Update(ticket);
            await dbContext.SaveChangesAsync();
        }



    }

}
