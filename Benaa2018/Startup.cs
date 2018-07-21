using Benaa2018.Data;
using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Repository;
using Benaa2018.Helper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Benaa2018
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
            services.AddDbContext<SBSDbContext>(options => options.UseSqlServer(@"Data Source=DESKTOP-O2C68VT;Initial Catalog=SBS-2018-New;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            services.AddAuthentication("SBSSecurityScheme")
                    .AddCookie("SBSSecurityScheme", options =>
                    {
                        options.AccessDeniedPath = new PathString("/Login/Index");
                        options.Cookie = new CookieBuilder
                        {
                            HttpOnly = true,
                            Name = ".Fiver.Security.Cookie",
                            Path = "/",
                            SameSite = SameSiteMode.Lax,
                            SecurePolicy = CookieSecurePolicy.SameAsRequest
                        };
                        options.Events = new CookieAuthenticationEvents
                        {
                            OnSignedIn = context =>
                            {
                                return Task.CompletedTask;
                            },
                            OnSigningOut = context =>
                            {
                                return Task.CompletedTask;
                            },
                            OnValidatePrincipal = context =>
                            {
                                return Task.CompletedTask;
                            }
                        };
                        options.LoginPath = new PathString("/Login");
                        options.SlidingExpiration = true;
                    });
            services.AddTransient<IUserMasterRepository, UserMasterRepository>();
            services.AddTransient<ILoginDetailsInfoRepository, LoginDetailsInfoRepository>();
            services.AddTransient<IProjectMasterRepository, ProjectMasterRepository>();
            services.AddTransient<IMenuMasterRepository, MenuMasterRepository>();
            services.AddTransient<IProjectTypeMasterRepository, ProjectTypeMasterRepository>();
            services.AddTransient<IProjectSubcontractorConfigRepository, ProjectSubcontractorConfigRepository>();
            services.AddTransient<IProjectStatusMasterRepository, ProjectStatusMasterRepository>();
            services.AddTransient<IProjectScheduleMasterRepository, ProjectScheduleMasterRepository>();
            services.AddTransient<IProjectManagerMasterRepository, ProjectManagerMasterRepoitory>();
            services.AddTransient<IProjectGroupRepository, ProjectGroupRepository>();
            services.AddTransient<IToDoMasterRepoisitory, ToDoMasterRepoisitory>();
            services.AddTransient<ISubContractorMasterRepository, SubContractorMasterRepository>();
            services.AddTransient<IProjectUserIntConfigMasterRepository, ProjectUserIntConfigMasterRepository>();
            services.AddTransient<IOwnerMasterRepoisitory, OwnerMasterRepoisitory>();
            services.AddTransient<IWarrentyAlertRepoisitory, WarrentyAlertRepoisitory>();
            services.AddTransient<IProjectColorRepoisitory, ProjectColorRepoisitory>();
            services.AddTransient<ICompanyMasterRespository, CompanyMasterRespository>();
            services.AddTransient<ICompanyMasterHelper, CompanyMasterHelper>();
            services.AddTransient<IDetaildPermissionRepository, DetaildPermissionRepository>();

            services.AddTransient<IMenuMasterHelper, MenuMasterHelper>();
            services.AddTransient<IOwnerMasterHelper, OwnerMasterHelper>();
            services.AddTransient<IProjectColorHelper, ProjectColorHelper>();
            services.AddTransient<IProjectGroupHelper, ProjectGroupHelper>();
            services.AddTransient<IProjectMasterHelper, ProjectMasterHelper>();
            services.AddTransient<IProjectScheduleMasterHelper, ProjectScheduleMasterHelper>();
            services.AddTransient<IProjectStatusMasterHelper, ProjectStatusMasterHelper>();
            services.AddTransient<ISubContractorHelper, SubContractorHelper>();
            services.AddTransient<IToDoMasterHelper, ToDoMasterHelper>();
            services.AddTransient<IUserMasterHelper, UserMasterHelper>();
            services.AddTransient<IWarrentyAlertHelper, WarrentyAlertHelper>();
            services.AddTransient<IDetaildPermissionHelper, DetaildPermissionHelper>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Login}/{action=Index}/{id?}");
            //});
        }
    }
}
