using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Data;
using SistemaTarefas.Repository;
using SistemaTarefas.Repository.Interfaces;

namespace SistemaTarefas
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

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<AppDbContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")
                ));


            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipe  line.
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