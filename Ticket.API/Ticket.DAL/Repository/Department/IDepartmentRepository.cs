using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.DAL
{
    public interface IDepartmentRepository
    {
        Department? GetWithTicketsAndDeveloperCountById(int id);
    }
}
