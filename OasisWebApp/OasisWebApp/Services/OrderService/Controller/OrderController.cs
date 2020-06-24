using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OasisWebApp.Controllers.Custom;
using OasisWebApp.DTOs;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OasisWebApp.Services.OrderService.Controller
{
    public class OrderController : CustomController
    {
        private readonly OrderService orderService;
        public OrderController(OrderService orderService)
        {
            this.orderService = orderService;
        }

        [Route("Orders")]
        [Authorize]
        public async Task<IActionResult> Orders()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = await orderService.GetOrdersAsync(userId);
            return View(orders);
        }

        [Route("New")]
        [Authorize]
        public async Task<IActionResult> New(ICollection<TicketDto> tickets)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await orderService.CreateOrderAsync(userId, tickets);
            return Ok();
        }


    }
}
