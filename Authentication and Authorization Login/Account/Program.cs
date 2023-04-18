
using Account.Data;
using Account.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Account
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Database

            var connectionstring = builder.Configuration.GetConnectionString("School");
            builder.Services.AddDbContext<SchoolContext>(option=>option.UseSqlServer(connectionstring));

            #endregion

            #region Inject identity (userManager)
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 0;
            })
                        .AddEntityFrameworkStores<SchoolContext>()//uderstand it database
                        .AddDefaultTokenProviders();
            #endregion

            #region Authentication Service

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Cool";
                options.DefaultChallengeScheme = "Cool";
            })
        .AddJwtBearer("Cool", options =>
          {
              var secretKeyString = builder.Configuration.GetValue<string>("SecretKey");
              var secretyKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString ?? string.Empty);
              var secretKey = new SymmetricSecurityKey(secretyKeyInBytes);

              options.TokenValidationParameters = new TokenValidationParameters
              {
                  IssuerSigningKey = secretKey,
                  ValidateIssuer = false,
                  ValidateAudience = false,
              };
          });

            #endregion

            #region Authorization

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("JustAdmins", policy => policy
                    .RequireClaim(ClaimTypes.Role, "Admin")
                    .RequireClaim(ClaimTypes.NameIdentifier));

                options.AddPolicy("UsersorAdmins", policy => policy
                    .RequireClaim(ClaimTypes.Role, "Admin", "User")
                    .RequireClaim(ClaimTypes.NameIdentifier));
            });

            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}