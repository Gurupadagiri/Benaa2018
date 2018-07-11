using Benaa2018.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Benaa2018.Data
{
    public class SBSDbContext : DbContext
    {
        public SBSDbContext(DbContextOptions<SBSDbContext> options) : base(options)
        {

        }
        public DbSet<UserMaster> UserMasters { get; set; }
        public DbSet<LoginDetailsInfo> LoginDetailsInfo { get; set; }
        public DbSet<MenuMaster> MenuMasters { get; set; }
        public DbSet<ProjectMaster> ProjectMasters { get; set; }
        public DbSet<ProjectScheduleMaster> ProjectScheduleMasters { get; set; }
        public DbSet<ProjectStatusMaster> ProjectStatusMasters { get; set; }
        public DbSet<ProjectSubcontractorConfig> ProjectSubcontractorConfigs { get; set; }
        public DbSet<ProjectTypeMaster> ProjectTypeMasters { get; set; }
        public DbSet<ProjectManagerMaster> ProjectManagerMasters { get; set; }
        public DbSet<ToDoMaster> ToDoMasters { get; set; }
        public DbSet<WarrentyAlert> WarrentyAlerts { get; set; }
        public DbSet<ProjectGroup> ProjectGroups { get; set; }
        public DbSet<SubContractorMaster> SubContractorMasters { get; set; }
        public DbSet<ProjectUserIntConfigMaster> ProjectUserIntConfigMasters { get; set; }
        public DbSet<OwnerMaster> OwnerMasters { get; set; }
        public DbSet<ProjectColorMaster> ProjectColorMasters { get; set; }
        public DbSet<CompanyMaster> CompanyMasters { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // EF Core 2 doesnt support Cascade on delete for in Memory Database
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=DESKTOP-O2C68VT;Initial Catalog=SBS-2018-New;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
