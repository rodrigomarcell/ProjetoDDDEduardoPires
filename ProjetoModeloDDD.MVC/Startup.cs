using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoModeloDDD.Aplicacao;
using ProjetoModeloDDD.Aplicacao.Interface;
using ProjetoModeloDDD.Dominio.Interfaces.Repositorios;
using ProjetoModeloDDD.Dominio.Interfaces.Servicos;
using ProjetoModeloDDD.Dominio.Servicos;
using ProjetoModeloDDD.Infra.Dados.Repositorios;
using System;

namespace ProjetoModeloDDD.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public  void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();  

            services.AddScoped<IRepositorioCliente, ClienteRepositorio>();
            services.AddScoped<IAppServicoCliente, AppServicoCliente>();
            services.AddScoped<IServicoCliente, ServicoCliente>();

            services.AddScoped<IRepositorioProduto, ProdutoRepositorio>();
            services.AddScoped<IAppServicoProduto, AppServicoProduto>();
            services.AddScoped<IServicoProduto, ServicoProduto>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
