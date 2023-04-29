
using Microsoft.EntityFrameworkCore;
using Ticket.BLL;
using Ticket.BLL.Managers;
using Ticket.DAL;

namespace Ticket.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Cors

            var allowAllPolicy = "AlloAll";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(allowAllPolicy, policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            #endregion


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();





            //connection string
            var connectionString = builder.Configuration.GetConnectionString("Ticket");
            builder.Services.AddDbContext<TicketContext>(
                options => options.UseSqlServer(connectionString));

            //inject IRepository
            builder.Services.AddScoped<ITicketRepository, TicketRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            //inject IManager
            builder.Services.AddScoped<ITicketManager, TicketManager>();
            builder.Services.AddScoped<IDepartmentManager, DepartmentManager>();





            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}