using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SI_Request.Models.DataModel;
using SI_Request.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SI_Request.Models.Resptory;
using SI_Request.Models.InterfaceModel;

namespace SI_Request
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection Services)
        {
            Services.AddDbContext<DBCONTEX>(options => options.UseSqlServer(Configuration["NelsonMandelaUniversty:ConnectionString"]));
            Services.AddIdentity<UserModel, IdentityRoleModel>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;

                options.SignIn.RequireConfirmedEmail = false;
            })
                .AddEntityFrameworkStores<DBCONTEX>()
                .AddDefaultTokenProviders()
                ;
            Services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
.RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            })
                .AddXmlDataContractSerializerFormatters();
            Services.AddTransient<IAdminModel, RespAdminModel>();
            Services.AddTransient<IComputerModel, RespComputerModel>();
            Services.AddTransient<ICourseModel, RespCourseModel>();
            Services.AddTransient<IModuleAssgnModel, RespModuleAssgnModel>();
            Services.AddTransient<IModuleModel, RespModuleModel>();
            Services.AddTransient<IRequestModel, RespRequestModel>();
            Services.AddTransient<IRoomModel, RespRoomModel>();
            Services.AddTransient<IStudentAssistance, RespStudentAssistance>();
            Services.AddTransient<IStudentModel, RespStudentModel>();
            Services.AddTransient<ITaskCategoryModel, RespTaskCategoryModel>();
            Services.AddTransient<ITaskModel, RespTaskModel>();
            Services.AddRazorPages();
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
                app.UseExceptionHandler("Account/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Index}/{id?}");
            });
        }
    }
}
