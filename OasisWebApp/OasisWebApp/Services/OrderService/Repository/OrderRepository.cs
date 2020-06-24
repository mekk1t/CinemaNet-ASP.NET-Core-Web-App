using Microsoft.EntityFrameworkCore;
using OasisWebApp.Database;
using OasisWebApp.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OasisWebApp.Services.OrderService.Repository
{
    public class OrderRepository
    {
        private readonly OasisCinemaDbContext dbContext;

        public OrderRepository(OasisCinemaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<IEnumerable<Order>> GetOrdersAsync(string userId)
        {
            var orders = dbContext.Orders
                .AsNoTracking()
                .Include(o => o.Tickets)
                .Where(o => o.UserId == userId)
                .AsEnumerable();
            return Task.FromResult(orders);
        }

        public async Task<Order> CreateOrderAsync(string userId, ICollection<Ticket> tickets)
        {
            var order = new Order()
            {
                CompletedOn = DateTime.Now,
                UserId = userId,
                Tickets = tickets                
            };
            var result = await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

    }
}
