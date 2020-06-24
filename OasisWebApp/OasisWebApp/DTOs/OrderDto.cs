using System;
using System.Collections.Generic;

namespace OasisWebApp.DTOs
{
    public class OrderDto
    {
        public DateTime CompletedOn { get; set; }
        public ICollection<TicketDto> Tickets { get; set; }
    }
}
