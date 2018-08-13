﻿using Benaa2018.Data.Model;
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
        public DbSet<CalendarScheduledItem> CalendarScheduledItems { get; set; }
        public DbSet<PredecessorInformation> PredecessorInformations { get; set; }
        public DbSet<DetaildPermission> DetaildPermissions { get; set; }
        public DbSet<ToDoMasterDetails> ToDoMasterDetailss { get; set; }
        public DbSet<TagMaster> TagMasterDetailss { get; set; }
        public DbSet<ToDoTag> ToDoTags { get; set; }
        public DbSet<ToDochecklistDetails> ToDochecklistDetails { get; set; }
        public DbSet<ToDochecklist> ToDochecklists { get; set; }
        public DbSet<TagMaster> TagMasters { get; set; }
        public DbSet<ToDoAssign> ToDoAssigns { get; set; }
        public DbSet<CalendarPhase> CalendarPhases { get; set; }
        public DbSet<CalendarTag> CalendarTags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // EF Core 2 doesnt support Cascade on delete for in Memory Database
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=kuttu;Initial Catalog=SBS-2018-New;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
