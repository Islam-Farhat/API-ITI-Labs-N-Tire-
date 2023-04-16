using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.BLL
{
    public interface IDepartmentManager
    {
        DepartmentDetailsDto? GetDetails(int id);
    }
}
