using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.BLL.Dtos.Tickets
{
    public class TicketWithCountDevDto
    {
        public int Id { get; set; }
        public string? Description { get; set; } = string.Empty;
        public required int DevelopersCount { get; set; }
    }
}
