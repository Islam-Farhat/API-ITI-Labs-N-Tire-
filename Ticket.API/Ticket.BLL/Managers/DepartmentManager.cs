using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.DAL;

namespace Ticket.BLL.Managers
{
    public class DepartmentManager:IDepartmentManager
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentManager(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        public DepartmentDetailsDto? GetDetails(int id)
        {
            Department? result = departmentRepository.GetWithTicketsAndDeveloperCountById(id);
            if (result == null) return null;

            return new DepartmentDetailsDto
            {
                Id = result.Id,
                Name = result.Name,
                Departments = result.Tickets.Select(t => new Dtos.Tickets.TicketWithCountDevDto
                {
                    Id = t.Id,
                    Description = t.Description,
                    DevelopersCount = t.Developer.Count,
                }).ToList()
            };

        }
    }
}
