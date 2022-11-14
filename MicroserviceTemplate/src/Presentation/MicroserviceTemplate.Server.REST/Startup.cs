using System.Reflection;
using FluentValidation;
using MediatR;
using MicroserviceTemplate.Application.Common;
using MicroserviceTemplate.Application.Interfaces;
using MicroserviceTemplate.Application.ToDo.Queries.GetToDoList;
using MicroserviceTemplate.Persistence;
using MicroserviceTemplate.Persistence.ToDo;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace MicroserviceTemplate.Server.REST
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<ToDoDataContext>(options => options.UseSqlServer(_configuration.GetConnectionString("ToDoDataConnection")));
            services.AddMediatR(typeof(GetToDoListQuery).GetTypeInfo().Assembly);
            services.AddValidatorsFromAssembly(typeof(GetToDoListQuery).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationHandler<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceHandler<,>));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDo.API", Version = "v1" });
            });
            services.AddTransient<IToDoQueryRepository, ToDoQueryRepository>();
            services.AddTransient<IToDoCommandRepository, ToDoCommandRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo API V1");
                });
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(builder => builder.WithOrigins("*")
                              .AllowAnyMethod()
                              .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            InitializeDatabase(app);
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<ToDoDataContext>().Database.Migrate();
            }
        }
    }
}
