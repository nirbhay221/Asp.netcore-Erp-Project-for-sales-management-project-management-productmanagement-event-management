using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Rotativa.AspNetCore;

namespace EmpManagement
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<AppDbContext>();
            services.AddSession();
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                               .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddTransient<IEmployeeRepository, SQLEmployeeRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.C:\Users\ashish\source\repos\EmpManagement\EmpManagement\libman.json
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Logger video11 kudvenkut
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            // defaultFilesOptions.DefaultFileNames.Clear();//clears the default path ie default.html
            //defaultFilesOptions.DefaultFileNames.Add("foo.html");
            // app.UseDefaultFiles(defaultFilesOptions);//only points to default path,default.html or index.html
            // app.UseStaticFiles();

            //Alternative to above code is this
           // FileServerOptions fileServerOptions = new FileServerOptions();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();//clears the default path ie default.html
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("foo.html");
            // app.UseFileServer(fileServerOptions);//only points to default path,default.html or index.html

            app.UseStaticFiles();// this is what he is using in video 14

            // app.UseMvcWithDefaultRoute();
            app.UseAuthentication();

            app.UseSession();
            RotativaConfiguration.Setup(env);
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=MainHome}/{action=NewIndex}/{id?}");

            });

            //delegates and lamda expressions
            //app.Run(async (context) =>
         //   {
              //  await context.Response
               // .WriteAsync("Hello World");
                //.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
           // });
        }
    }
}
