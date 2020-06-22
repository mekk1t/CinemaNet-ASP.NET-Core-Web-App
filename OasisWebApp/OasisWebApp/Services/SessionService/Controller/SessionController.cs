using Microsoft.AspNetCore.Mvc;
using OasisWebApp.Controllers.Custom;
using OasisWebApp.Services.SessionService.Repository.Filter;
using OasisWebApp.Services.SessionService.Services.Interface;
using System;
using System.Threading.Tasks;

namespace OasisWebApp.Services.SessionService.Controller
{
    public class SessionController : CustomController
    {
        private readonly ISessionService sessionService;

        public SessionController(
            [FromServices] ISessionService sessionService)
        {
            this.sessionService = sessionService;
        }

        [Route("sessions/{dateFilter}/{cinemaFilter}/{filmFilter}")]
        public async Task<ActionResult> Sessions(
            [FromRoute] string dateFilter,
            [FromRoute] string cinemaFilter,
            [FromRoute] string filmFilter)
        {
            SessionFilter filter = new SessionFilter()
            {
                SessionDate = Convert.ToDateTime(dateFilter),
                CinemaName = cinemaFilter,
                FilmName = filmFilter
            };
            var sessions = await sessionService.FindAsync(filter);
            return View(sessions);
        }

        [Route("sessions/{Id}")]
        public async Task<ActionResult> Session(
            [FromRoute] int Id)
        {
            var session = await sessionService.GetAsync(Id);
            return View(session);
        }
    }
}
