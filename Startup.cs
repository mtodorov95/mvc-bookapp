using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookStore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Enable certain app features (MVC...)
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            // Ref to the DB Context to use
            services.AddDbContext<BookStoreContext>(options => options.UseSqlServer("Server=.;Database=BookStore;Integrated Security=True;"));
            services.AddScoped<BookRepository, BookRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Check environment
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Middleware goes here
            // app.Use(async (context, next) =>
            // {
            //     await context.Response.WriteAsync("Some message");
            //     await next();
            // });

            // app.Use(async (context, next) =>
            // {
            //     await context.Response.WriteAsync("Second message");
            // });

            // Enables static files
            app.UseStaticFiles();

            // Enables routing
            app.UseRouting();

            // Use to specify the routes
            app.UseEndpoints(endpoints =>
            {
                // Get request to index
                // endpoints.MapGet("/", async context =>
                // {
                //     await context.Response.WriteAsync(env.EnvironmentName);
                // });

                // Uses HomeController and Index method by default
                endpoints.MapDefaultControllerRoute();

                // Custom routing
                // Nesting the app in a bookApp folder
                //endpoints.MapControllerRoute(
                //    name: "Default",
                //    pattern: "bookApp/{controller=Home}/{action=Index}/{id?}"
                //    );
            });
        }
    }
}
