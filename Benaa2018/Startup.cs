using Benaa2018.Data;
using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Repository;
using Benaa2018.Helper;
using Benaa2018.Helper.Interface;
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
            services.AddDbContext<SBSDbContext>(options => options.UseSqlServer(@"Data Source=DESKTOP-O2C68VT;Initial Catalog=SBS-2018-New-ThirdParty;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=True;").EnableSensitiveDataLogging());
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

            services.AddDbContext<SBSDbContext>(c =>
            c.UseInMemoryDatabase(System.Guid.NewGuid().ToString()).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.AddScoped<IUserMasterRepository, UserMasterRepository>();
            services.AddScoped<ILoginDetailsInfoRepository, LoginDetailsInfoRepository>();
            services.AddScoped<IProjectMasterRepository, ProjectMasterRepository>();
            services.AddScoped<IMenuMasterRepository, MenuMasterRepository>();
            services.AddScoped<IProjectTypeMasterRepository, ProjectTypeMasterRepository>();
            services.AddScoped<IProjectSubcontractorConfigRepository, ProjectSubcontractorConfigRepository>();
            services.AddScoped<IProjectStatusMasterRepository, ProjectStatusMasterRepository>();
            services.AddScoped<IProjectScheduleMasterRepository, ProjectScheduleMasterRepository>();
            services.AddScoped<IProjectManagerMasterRepository, ProjectManagerMasterRepoitory>();
            services.AddScoped<IProjectGroupRepository, ProjectGroupRepository>();
            services.AddScoped<IToDoMasterRepoisitory, ToDoMasterRepoisitory>();
            services.AddScoped<ISubContractorMasterRepository, SubContractorMasterRepository>();
            services.AddScoped<IProjectUserIntConfigMasterRepository, ProjectUserIntConfigMasterRepository>();
            services.AddScoped<IOwnerMasterRepoisitory, OwnerMasterRepoisitory>();
            services.AddScoped<IWarrentyAlertRepoisitory, WarrentyAlertRepoisitory>();
            services.AddScoped<IProjectColorRepoisitory, ProjectColorRepoisitory>();
            services.AddScoped<ICompanyMasterRespository, CompanyMasterRespository>();
            services.AddScoped<ICompanyMasterHelper, CompanyMasterHelper>();
            services.AddScoped<IDetaildPermissionRepository, DetaildPermissionRepository>();
            services.AddScoped<IToDoMasterDetailsRepository, ToDoMasterDetailsRepository>();
            services.AddScoped<ITagMasterRepository, TagMasterRepository>();
            services.AddScoped<IToDoTagRepository, ToDoTagRepository>();
            services.AddScoped<IToDoAssignRepository, ToDoAssignRepository>();
            services.AddScoped<IToDochecklistDetailsRepository, ToDochecklistDetailsRepository>();
            services.AddScoped<IToDochecklistRepository, ToDochecklistRepository>();
            services.AddScoped<ICalendarScheduledItemRepoisitory, CalendarScheduledItemRepository>();
            services.AddScoped<IPredecessorInformationRepository, PredecessorInformationRepository>();
            services.AddScoped<ICalendarPhaseRepository, CalendarPhaseRepository>();
            services.AddScoped<ICalendarTagRepository, CalendarTagRepository>();
            services.AddScoped<IGroupMasterRepository, GroupMasterRepository>();
            services.AddScoped<IMainActivityMasterRepository, MainActivityMasterRepository>();
            services.AddScoped<IActivityMasterRepository, ActivityMasterRepository>();
            services.AddScoped<IToDoMessageRepository, ToDoMessageRepository>();
            services.AddScoped<IVarianceMasterRepository, VarianceMasterRepository>();
            services.AddScoped<IProjectPlaningRepository, ProjectPlaningRepository>();
            services.AddScoped<IProjectBoqBudgetMasterRepository, ProjectBoqBudgetMasterRepository>();
            /*** Repository Added By Abhishek **************/
            services.AddScoped<ITaxMasterRepository, TaxMasterRepository>();
            services.AddScoped<IUnitMasterRepository, UnitMasterRepository>();
            services.AddScoped<IMarkupMasterRepository, MarkupMasterRepository>();




            services.AddScoped<IMenuMasterHelper, MenuMasterHelper>();
            services.AddScoped<IOwnerMasterHelper, OwnerMasterHelper>();
            services.AddScoped<IProjectColorHelper, ProjectColorHelper>();
            services.AddScoped<IProjectGroupHelper, ProjectGroupHelper>();
            services.AddScoped<IProjectMasterHelper, ProjectMasterHelper>();
            services.AddScoped<IProjectScheduleMasterHelper, ProjectScheduleMasterHelper>();
            services.AddScoped<IProjectStatusMasterHelper, ProjectStatusMasterHelper>();
            services.AddScoped<ISubContractorHelper, SubContractorHelper>();
            services.AddScoped<IToDoMasterHelper, ToDoMasterHelper>();
            services.AddScoped<IUserMasterHelper, UserMasterHelper>();
            services.AddScoped<IWarrentyAlertHelper, WarrentyAlertHelper>();
            services.AddScoped<IDetaildPermissionHelper, DetaildPermissionHelper>();
            services.AddScoped<IToDoMasterDetailsHelper, ToDoMasterDetailsHelper>();
            services.AddScoped<ITagMasterHelper, TagMasterHelper>();
            services.AddScoped<IToDoTagHelper, ToDoTagHelper>();
            services.AddScoped<IToDoAssignHelper, ToDoAssignHelper>();
            services.AddScoped<IToDoCheckListHelper, ToDoCheckListHelper>();
            services.AddScoped<IToDoCheckListDetailsHelper, ToDoCheckListDetailsHelper>();
            services.AddScoped<ICalendarScheduleHelper, CalendarScheduleHelper>();
            services.AddScoped<IGroupMasterHelper, GroupMasterHelper>();
            services.AddScoped<IMainActivityMasterHelper, MainActivityMasterHelper>();
            services.AddScoped<IActivityMasterHelper, ActivityMasterHelper>();
            services.AddScoped<IToDoMessageHelper, ToDoMessageHelper>();
            services.AddScoped<IVarianceMasterHelper, VarianceMasterHelper>();
            services.AddScoped<IProjectBoqBudgetMasterHelper, ProjectBoqBudgetMasterHelper>();
            services.AddScoped<IProjectPlaningHelper, ProjectPlaningHelper>();
            services.AddScoped<IMainActivityMasterHelper, MainActivityMasterHelper>();
            /** Services Added By Abhsihek**/
            services.AddScoped<ITaxMasterHelper, TaxMasterHelper>();
            services.AddScoped<IUnitMasterHelper, UnitMasterHelper>();
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

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
