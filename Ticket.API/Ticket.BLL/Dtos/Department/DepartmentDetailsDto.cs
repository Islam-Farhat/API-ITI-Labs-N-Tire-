using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.BLL.Dtos.Tickets;

namespace Ticket.BLL
{
    public class DepartmentDetailsDto
    {
        public required int Id { get; set; }
        public required string? Name { get; set; }
        public List<TicketWithCountDevDto> Departments { get; init; } = new();
    }
}
