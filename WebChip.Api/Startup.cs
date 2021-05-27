    using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebChip.Infra;
using WebChip.Infra.Context;
using WebChip.Infra.Repositories;
using WebChip.Domain.Handlers;
using WebChip.Domain.Repository;


namespace WebChip.Api
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
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("connectionString")));

            services.AddTransient<ClienteHandler, ClienteHandler>();
            services.AddTransient<IRepositoryCliente, RepositoryCliente>();
            services.AddTransient<IRepositoryEndereco, RepositoryEndereco>();
            services.AddTransient<IRepositoryHistoricoOferta, RepositoryHistoricoOferta>();
            services.AddTransient<IRepositoryProduto, RepositoryProduto>();
            services.AddTransient<IRepositoryStatus, RepositoryStatus>();
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
