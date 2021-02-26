using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NovaWeb.API.Bussiness;
using NovaWeb.API.Bussiness.Implementations;
using NovaWeb.API.Context;
using NovaWeb.API.Repository;
using RestWithASPNET.Repository;

namespace NovaWeb.API
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
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<NovaWebContext>(
                    options => options.UseNpgsql(
                        Configuration.GetConnectionString("NovaWebStrings")));
            services.AddControllers();

            services.AddScoped<IContatoBusiness, ContatoBusinessImplementation>();
            services.AddScoped<IContatoRepository, ContatoRepositoryImplementations>();

            services.AddScoped<ITelefoneBusiness, TelefoneBusinessImplementation>();
            services.AddScoped<ITelefoneRepository, TelefoneRepositoryImplementations>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NovaWeb.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NovaWeb.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
