
using ConnectToMongo.Models;
using ConnectToMongo.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ConnectToMongo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<CategoryStoreDatabaseSettings>(
                builder.Configuration.GetSection(nameof(CategoryStoreDatabaseSettings)));

            builder.Services.AddSingleton<ICategoryStoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<CategoryStoreDatabaseSettings>>().Value);

            builder.Services.AddSingleton<IMongoClient>(s =>
                    new MongoClient(builder.Configuration.GetValue<string>("CategoryStoreDatabaseSettings:ConnectionString")));

            builder.Services.AddScoped<ICategoryService, CategoryService>();


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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