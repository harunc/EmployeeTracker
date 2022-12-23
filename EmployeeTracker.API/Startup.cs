using EmployeeTracker.Data.Abstract;
using EmployeeTracker.Data.Concrete;
using EmployeeTracker.Service.Abstract;
using EmployeeTracker.Service.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using EmployeeTracker.Core;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.Cookies;
using EmployeeTracker.API.Helper;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeTracker.API
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy(name: MyAllowSpecificOrigins, policy =>
                {
                    policy.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                });
            });
            services.AddAuthorization(cfg => {
                cfg.AddPolicy("RolePolicy", policy => policy.Requirements.Add(new RoleRequirement()));
            });
            services.AddSession();
            services.AddSingleton<IAuthorizationHandler, RoleHandler>();
            services.AddAutoMapper(typeof(Startup));
            services.AddRazorPages();
            services.AddControllers();
            services.AddSingleton<IMachineRepo, MachineRepo>();
            services.AddSingleton<IMachineService, MachineManager>();
            services.AddSingleton<IProductRepo, ProductRepo>();
            services.AddSingleton<IProductService, ProductManager>();
            services.AddSingleton<IEmployeeRepo, EmployeeRepo>();
            services.AddSingleton<IEmployeeService, EmployeeManager>();
            services.AddSingleton<IEmployee_MachineRepo, Employee_MachineRepo>();
            services.AddSingleton<IEmployee_MachineService, E_MConnectionManager>();
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
