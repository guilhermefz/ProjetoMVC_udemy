using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetoMVC.Data;
using ProjetoMVC.Models.Interfaces;
using ProjetoMVC.Models.Services;
using ProjetoMVC.Controllers;
using ProjetoMVC.Mappers;
namespace ProjetoMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IVendedorService, VendedorService>();
            builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
            builder.Services.AddScoped<IRegistroVendasService, RegistroVendasService>();
            builder.Services.AddScoped<IProdutoService, ProdutoService>();


            var connectionString = builder.Configuration.GetConnectionString("ProjetoMVCContext");
            builder.Services.AddDbContext<ProjetoMVCContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
