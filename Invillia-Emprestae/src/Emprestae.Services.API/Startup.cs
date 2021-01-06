using AutoMapper;
using Emprestae.Application;
using Emprestae.Application.AutoMapper;
using Emprestae.Application.Interfaces;
using Emprestae.Domain.Interfaces.Repository;
using Emprestae.Domain.Interfaces.Service;
using Emprestae.Domain.Services;
using Emprestae.Infra.Data.Context;
using Emprestae.Infra.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Emprestae.Services.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Configurações AUTOMAPPER
            services.AddAutoMapper(typeof(MappingProfile));

            //TODO Injeção de dependência
            services.AddScoped<IGameAppService, GameAppService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGameRepository, GameRepository>();

            services.AddScoped<IAmigoAppService, AmigoAppService>();
            services.AddScoped<IAmigoService, AmigoService>();
            services.AddScoped<IAmigoRepository, AmigoRepository>();

            services.AddScoped<IEmprestimoAppService, EmprestimoAppService>();
            services.AddScoped<IEmprestimoService, EmprestimoService>();
            services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
