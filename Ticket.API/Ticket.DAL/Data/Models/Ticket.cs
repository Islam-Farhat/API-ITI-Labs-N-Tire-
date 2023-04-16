using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.DAL
{
    public class Ticket
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public int DepartmentId { get; set;}
        public virtual Department? Department { get; set; }
        public ICollection<Developer> Developer { get; set; } = new HashSet<Developer>();
    }
}
