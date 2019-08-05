using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Learning.NetCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Learning.NetCore.EntityFrameworkCore.Repositories;
using Learning.NetCore.Domain.IRepositories;
using Learning.NetCore.Application.ApplicationServices;

namespace Learing.NetCore.Mvc2
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var configBuilder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            configBuilder.AddEnvironmentVariables();
            Configuration = configBuilder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var mysqlConnectString = Configuration.GetConnectionString("default");
            services.AddDbContext<kuchenDbContext>(options => options.UseMySql(mysqlConnectString));
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IUserApplicationService,UserApplicationService>();
            services.AddMemoryCache();//内存缓存
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("Shared/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}"
                    );
            });
            SeedData.Init(app.ApplicationServices);

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
