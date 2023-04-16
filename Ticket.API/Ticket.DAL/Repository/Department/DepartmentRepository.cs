using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.DAL
{
    public class DepartmentRepository:IDepartmentRepository
    {
        private readonly TicketContext context;

        public DepartmentRepository(TicketContext context)//inject 
        {
            this.context = context;
        }
        public Department? GetWithTicketsAndDeveloperCountById(int id)
        {
            return context.Departments
            .Include(d => d.Tickets)
                .ThenInclude(t => t.Developer)
            .FirstOrDefault(p => p.Id == id);
        }
    }
}
