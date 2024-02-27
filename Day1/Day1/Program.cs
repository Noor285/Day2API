
using Day1.Models;
using Day1.Repositories;
using Day1.Services;
using Microsoft.EntityFrameworkCore;

namespace Day1
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

            // Add Database
            builder.Services.AddDbContext<APIdbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("con"));
            });

            builder.Services.AddScoped<StudentRepo>();
            builder.Services.AddScoped<DepartmentRepo>();

            builder.Services.AddCors(option =>
            {
                option.AddPolicy("MyPolicy", crosPolicy =>
                {
                    crosPolicy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            // Add Using Static Files
            app.UseStaticFiles();

            // Add Use Cors
            app.UseCors("MyPolicy");

            app.MapControllers();

            app.Run();
        }
    }
}
