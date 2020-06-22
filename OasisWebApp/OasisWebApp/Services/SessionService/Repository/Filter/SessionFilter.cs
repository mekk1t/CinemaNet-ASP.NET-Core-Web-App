using System;

namespace OasisWebApp.Services.SessionService.Repository.Filter
{
    public class SessionFilter
    {
        public DateTime SessionDate { get; set; }
        public string CinemaName { get; set; }
        public string FilmName { get; set; }
    }
}
