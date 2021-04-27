using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Productry.API.Configurations;
using Productry.Bussiness.Configurations;
using Productry.Bussiness.Interfaces;
using Productry.Bussiness.Services;
using Productry.Data.Context;
using Productry.Data.Repository;
using Productry.Services.Services;
using System;

namespace Productry.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ProductryDbContext>();
            
            //services.AddDbContext<ProductryDbContext>(opt => opt.UseInMemoryDatabase("InMemoryDb"));

            services.AddDbContext<ProductryDbContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                  b => b.MigrationsAssembly("Productry.Data")));

            services.Configure<ConexaoGateway>(Configuration.GetSection("Gateway"));

            services.AddScoped<IComprasRepository, ComprasRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<ICompraService, CompraService>();



            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo

                {
                    Title = "Curriculo Api",
                    Version = "v1",
                    Description = "A challenge resolution in ASP.NET Core Web API",
                    Contact = new OpenApiContact
                    {
                        Name = "Felipe Souza",
                        Email = "felipe6ouza@outlook.com",
                        Url = new Uri("https://github.com/felipe6ouza"),
                    },

                });
        });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Productry.API v1"));
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
