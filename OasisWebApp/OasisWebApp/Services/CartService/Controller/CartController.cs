using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.VisualBasic;
using OasisWebApp.Controllers.Custom;
using OasisWebApp.DTOs;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OasisWebApp.Services.CartService.Controller
{
    // TODO: TicketService, TicketRepository
    // TODO: как забрать со страницы объект

    public class CartController : CustomController
    {
        private readonly CartService cartService;
        private string userId, cartId;

        public override async Task OnActionExecutionAsync(
      ActionExecutingContext context,
      ActionExecutionDelegate next)
        {
            userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            cartId = await cartService.GetCartIdAsync(userId);
            await base.OnActionExecutionAsync(context, next);
        }



        public CartController(CartService cartService)
        {
            this.cartService = cartService;
        }               
        public async Task<IActionResult> Checkout()
        {
            var cartCheckedOut = await cartService.Checkout(cartId);
            ICollection<TicketDto> tickets = new Collection<TicketDto>();
            foreach (var cartItem in cartCheckedOut.CartItems)
            {
                tickets.Add(cartItem.Ticket);
            }
            return RedirectToAction("New", "Order", tickets);
        }

        public async Task<IActionResult> DeleteCart()
        {
            await cartService.DeleteCartAsync(cartId);
            return Ok();
        }

        [Route("Cart")]
        public async Task<IActionResult> Cart()
        {
            var cart = await cartService.GetCartAsync(userId);
            return View(cart);
        }
        public async Task<IActionResult> AddItem([FromRoute] int TicketId)
        {
            await cartService.AddItemToCartAsync(TicketId, userId);
            return RedirectToAction("Cart");
        }

        // TODO: забрать CartItemId, найти такой товар и удалить его из CartItems
        public async Task<IActionResult> RemoveItem(string cartItemId)
        {
            await cartService.RemoveItemsAsync(cartItemId, cartId);
            return RedirectToAction("Cart");
        }

    }
}
