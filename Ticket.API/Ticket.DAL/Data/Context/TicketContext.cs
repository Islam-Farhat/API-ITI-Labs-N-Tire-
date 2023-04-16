using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Ticket.DAL;

namespace Ticket.DAL
{
    public class TicketContext : DbContext
    {
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Developer> Developers => Set<Developer>();
        public DbSet<Department> Departments => Set<Department>();
        public TicketContext(DbContextOptions<TicketContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seeding 

            #region Seeding Department

            var departments = new List<Department>
            {
                  new Department {Id= 1,Name= "Department1"},
                  new Department {Id= 2,Name= "Department2"},
                  new Department {Id = 3, Name = "Department3"},
                  new Department {Id = 4, Name = "Department4"},
                  new Department {Id = 5, Name = "Department5"},
                  new Department {Id = 6, Name = "Department6"},
                  new Department {Id = 7, Name = "Department7"},
                  new Department {Id = 8, Name = "Department8"},
                  new Department {Id = 9, Name = "Department9"},
                  new Department {Id = 10, Name = "Department10"},
                };

            #endregion
            #region Tickets

            var tickets = new List<Ticket>
                {
                  new Ticket { Id= 1,  Description="this my discription..", Title= "Dana", DepartmentId= 5 },
                  new Ticket { Id= 2,  Description="this my discription..", Title= "Isaac", DepartmentId= 7 },
                  new Ticket { Id= 3,  Description="this my discription..", Title= "Damon", DepartmentId= 9 },
                  new Ticket { Id= 4,  Description="this my discription..", Title= "Miriam", DepartmentId= 8 },
                  new Ticket { Id= 5,  Description="this my discription..", Title= "Terence", DepartmentId= 7 },
                  new Ticket { Id= 6,  Description="this my discription..", Title= "Roosevelt", DepartmentId= 1 },
                  new Ticket { Id= 7,  Description="this my discription..", Title= "Eduardo", DepartmentId= 9 },
                  new Ticket { Id= 8,  Description="this my discription..", Title= "Wilbert", DepartmentId= 8 },
                  new Ticket { Id= 9,  Description="this my discription..", Title= "Tasha", DepartmentId= 5 },
                  new Ticket { Id= 10, Description="this my discription..", Title= "Max", DepartmentId= 1 },
                  new Ticket { Id= 11, Description="this my discription..", Title= "Bridget", DepartmentId= 2 },
                  new Ticket { Id= 12, Description="this my discription..", Title= "Juan", DepartmentId= 8 },
                  new Ticket { Id= 13, Description="this my discription..", Title= "Krystal", DepartmentId= 10 },
                  new Ticket { Id= 14, Description="this my discription..", Title= "Erma", DepartmentId= 10 },
                  new Ticket { Id= 15, Description="this my discription..", Title= "Orlando", DepartmentId= 6 },
                  new Ticket { Id= 16, Description="this my discription..", Title= "Marvin", DepartmentId= 5 },
                  new Ticket { Id= 17, Description="this my discription..", Title= "Lamar", DepartmentId= 4 },
                  new Ticket { Id= 18, Description="this my discription..", Title= "Joe", DepartmentId= 7 },
                  new Ticket { Id= 19, Description="this my discription..", Title= "Wendell", DepartmentId= 8 },
                  new Ticket { Id= 20, Description="this my discription..", Title= "Sandra", DepartmentId= 4 },
                  new Ticket { Id= 21, Description="this my discription..", Title= "Stephanie", DepartmentId= 6 },
                  new Ticket { Id= 22, Description="this my discription..", Title= "Ervin", DepartmentId= 7 },
                  new Ticket { Id= 23, Description="this my discription..", Title= "Beth", DepartmentId= 4 },
                  new Ticket { Id= 24, Description="this my discription..", Title= "Gretchen", DepartmentId= 7 },
                  new Ticket { Id= 25, Description="this my discription..", Title= "Gwendolyn", DepartmentId= 2 },
                  new Ticket { Id= 26, Description="this my discription..", Title= "Jerry", DepartmentId= 7 },
                  new Ticket { Id= 27, Description="this my discription..", Title= "Mitchell", DepartmentId= 6 },
                  new Ticket { Id= 28, Description="this my discription..", Title= "Maggie", DepartmentId= 8 },
                  new Ticket { Id= 29, Description="this my discription..", Title= "Sandy", DepartmentId= 3 },
                  new Ticket { Id= 30, Description="this my discription..", Title= "Lloyd", DepartmentId= 2 },
                };

            #endregion
            #region Developers

            var developers = new List<Developer>
                {
                  new Developer { Id= 1, Name= "Diabetes" },
                  new Developer { Id= 2, Name= "Hypertension" },
                  new Developer { Id= 3, Name= "Asthma" },
                  new Developer { Id= 4, Name= "Depression" },
                  new Developer { Id= 5, Name= "Arthritis" },
                  new Developer { Id= 6, Name= "Allergy" },
                  new Developer { Id= 7, Name= "Flu" },
                };

            #endregion

            modelBuilder.Entity<Department>().HasData(departments);//doctor
            modelBuilder.Entity<Ticket>().HasData(tickets);//patient
            modelBuilder.Entity<Developer>().HasData(developers);//issue

            #endregion
        }
    }
}
