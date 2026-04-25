
using API.Context;
using API.Filters;
using API.MiddleWares;
using API.Models;
using API.Repo;
using Microsoft.EntityFrameworkCore;
using Swashbuckle;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<GlobalExceptionFilter>();
            });
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            //Context
            builder.Services.AddDbContext<APIContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("default")));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped(typeof(IStudentRepository), typeof(StudentRepository));
            builder.Services.AddScoped(typeof(IDepartmentRepository), typeof(DepartmentRepository));
            //swagger
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
