﻿// <auto-generated />
using Benaa2018.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Benaa2018.Data.Migrations
{
    [DbContext(typeof(SBSDbContext))]
    [Migration("20180617112207_SBSNew")]
    partial class SBSNew
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Benaa2018.Data.Model.CompanyMaster", b =>
                {
                    b.Property<int>("Org_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Company_Name");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Latitude");

                    b.Property<string>("Longitude");

                    b.HasKey("Org_ID");

                    b.ToTable("Company_Master");
                });

            modelBuilder.Entity("Benaa2018.Data.Model.LoginDetailsInfo", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastLoginDate");

                    b.Property<DateTime>("LoginDateTime");

                    b.HasKey("UserId");

                    b.ToTable("Login_Details_Info");
                });

            modelBuilder.Entity("Benaa2018.Data.Model.MenuMaster", b =>
                {
                    b.Property<int>("Menu_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Created_By");

                    b.Property<DateTime>("Created_Date");

                    b.Property<string>("CssClass");

                    b.Property<bool>("Delflag");

                    b.Property<string>("Menu_Name");

                    b.Property<string>("Modified_By");

                    b.Property<DateTime>("Modified_Date");

                    b.Property<int>("PatentId");

                    b.HasKey("Menu_ID");

                    b.ToTable("Menu_Master");
                });

            modelBuilder.Entity("Benaa2018.Data.Model.OwnerMaster", b =>
                {
                    b.Property<int>("Owner_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessMethod");

                    b.Property<bool>("Active");

                    b.Property<string>("Address");

                    b.Property<bool>("AllowLockedSelections");

                    b.Property<bool>("AllowOrderRequests");

                    b.Property<bool>("AllowPaymentsTab");

                    b.Property<bool>("AllowWarrantyClaims");

                    b.Property<string>("City");

                    b.Property<string>("Created_By");

                    b.Property<DateTime>("Created_Date");

                    b.Property<string>("Email");

                    b.Property<string>("Mobile_No");

                    b.Property<string>("Modified_By");

                    b.Property<DateTime>("Modified_Date");

                    b.Property<int>("Org_ID");

                    b.Property<string>("OwnerActivation");

                    b.Property<string>("OwnerCalendar");

                    b.Property<string>("OwnerInformation");

                    b.Property<string>("Owner_Name");

                    b.Property<string>("Profile_Picture");

                    b.Property<int>("Project_ID");

                    b.Property<bool>("ShowBudgetPurchaseOrders");

                    b.Property<bool>("ShowProjectPrice");

                    b.Property<string>("State");

                    b.Property<string>("Telephone");

                    b.Property<string>("Zip");

                    b.HasKey("Owner_ID");

                    b.ToTable("Owner_Master");
                });

            modelBuilder.Entity("Benaa2018.Data.Model.ProjectColorMaster", b =>
                {
                    b.Property<int>("ProjectColorId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDisable");

                    b.Property<string>("ProjectColorName");

                    b.HasKey("ProjectColorId");

                    b.ToTable("Project_Color");
                });

            modelBuilder.Entity("Benaa2018.Data.Model.ProjectGroup", b =>
                {
                    b.Property<int>("Project_Goup_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Created_By");

                    b.Property<DateTime>("Created_Date");

                    b.Property<string>("Modified_By");

                    b.Property<DateTime>("Modified_Date");

                    b.Property<string>("Project_Group_Name");

                    b.Property<int>("User_ID");

                    b.HasKey("Project_Goup_ID");

                    b.ToTable("Project_Group");
                });

            modelBuilder.Entity("Benaa2018.Data.Model.ProjectManagerMaster", b =>
                {
                    b.Property<int>("Manager_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Created_By");

                    b.Property<DateTime>("Created_Date");

                    b.Property<string>("Manager_Name");

                    b.Property<string>("Modified_By");

                    b.Property<DateTime>("Modified_Date");

                    b.Property<int>("Org_ID");

                    b.HasKey("Manager_ID");

                    b.ToTable("Project_Manager_Master");
                });

            modelBuilder.Entity("Benaa2018.Data.Model.ProjectMaster", b =>
                {
                    b.Property<int>("Project_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Address");

                    b.Property<float>("Built_Up_Area");

                    b.Property<string>("City");

                    b.Property<decimal>("Contract_Price");

                    b.Property<decimal>("Country_ID");

                    b.Property<string>("Created_By");

                    b.Property<DateTime>("Created_Date");

                    b.Property<string>("Group_No");

                    b.Property<string>("Internal_Notes");

                    b.Property<string>("Lot_Info");

                    b.Property<string>("Modified_By");

                    b.Property<DateTime>("Modified_Date");

                    b.Property<int>("No_Of_Unit");

                    b.Property<long>("Org_ID");

                    b.Property<string>("Permit_No");

                    b.Property<string>("Project_Group_ID");

                    b.Property<string>("Project_Manager_id");

                    b.Property<string>("Project_Name");

                    b.Property<string>("Project_Prefix");

                    b.Property<int>("Project_Type_ID");

                    b.Property<float>("Project_land_Cost");

                    b.Property<int>("Sequence");

                    b.Property<string>("State");

                    b.Property<int>("Status_ID");

                    b.Property<string>("Sub_Notes");

                    b.Property<int>("User_ID");

                    b.Property<string>("Zip");

                    b.HasKey("Project_ID");

                    b.ToTable("Project_Master");
                });

            modelBuilder.Entity("Benaa2018.Data.Model.ProjectScheduleMaster", b =>
                {
                    b.Property<int>("Schedule_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Actual_Completion");

                    b.Property<DateTime>("Actual_Start");

                    b.Property<string>("Created_By");

                    b.Property<DateTime>("Created_Date");

                    b.Property<string>("Modified_By");

                    b.Property<DateTime>("Modified_Date");

                    b.Property<int>("Org_ID");

                    b.Property<int>("ProjectColorId");

                    b.Property<int>("Project_Color_ID");

                    b.Property<int>("Project_ID");

                    b.Property<DateTime>("Projected_Completion");

                    b.Property<DateTime>("Projected_Start");

                    b.Property<string>("Works_Days");

                    b.HasKey("Schedule_ID");

                    b.ToTable("Project_schedule_Master");
                });

            modelBuilder.Entity("Benaa2018.Data.Model.ProjectStatusMaster", b =>
                {
                    b.Property<int>("Status_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Created_By");

                    b.Property<DateTime>("Created_Date");

                    b.Property<string>("Modified_By");

                    b.Property<DateTime>("Modified_Date");

                    b.Property<int>("Org_ID");

                    b.Property<string>("Status_Name");

                    b.HasKey("Status_ID");

                    b.ToTable("Project_Status_Master");
                });

            modelBuilder.Entity("Benaa2018.Data.Model.ProjectSubcontractorConfig", b =>
                {
                    b.Property<int>("SubContractor_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Created_By");

                    b.Property<DateTime>("Created_Date");

                    b.Property<string>("Modified_By");

                    b.Property<DateTime>("Modified_Date");

                    b.Property<int>("Org_ID");

                    b.Property<decimal>("Project_ID");

                    b.Property<string>("Subcontractor_Name");

                    b.Property<bool>("View_Access");

                    b.HasKey("SubContractor_ID");

                    b.ToTable("Project_Subcontractor_config");
                });

            modelBuilder.Entity("Benaa2018.Data.Model.ProjectTypeMaster", b =>
                {
                    b.Property<int>("Project_Type_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Created_By");

                    b.Property<DateTime>("Created_Date");

                    b.Property<string>("Modified_By");

                    b.Property<DateTime>("Modified_Date");

                    b.Property<int>("Org_ID");

                    b.Property<string>("Project_Type_Name");

                    b.HasKey("Project_Type_ID");

                    b.ToTable("Project_Type_Master");
                });

            modelBuilder.Entity("Benaa2018.Data.Model.ProjectUserIntConfigMaster", b =>
                {
                    b.Property<int>("Internal_User_Con_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Org_ID");

                    b.Property<int>("Project_ID");

                    b.Property<bool>("Recive_Notification");

                    b.Property<int>("UserID");

                    b.Property<string>("User_Name");

                    b.Property<bool>("View_Access");

                    b.HasKey("Internal_User_Con_Id");

                    b.ToTable("Project_User_Int_Config_Master");
                });

            modelBuilder.Entity("Benaa2018.Data.Model.SubContractorMaster", b =>
                {
                    b.Property<int>("SubContractor_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Beneficiary");

                    b.Property<string>("CR_NO");

                    b.Property<decimal>("Catogery_ID");

                    b.Property<string>("Contact_Persion");

                    b.Property<int>("Country_ID");

                    b.Property<string>("Created_By");

                    b.Property<DateTime>("Created_Date");

                    b.Property<string>("Email");

                    b.Property<string>("Fax");

                    b.Property<string>("Mobile");

                    b.Property<string>("Modified_By");

                    b.Property<DateTime>("Modified_Date");

                    b.Property<string>("Name");

                    b.Property<int>("Org_ID");

                    b.Property<string>("Tel");

                    b.HasKey("SubContractor_ID");

                    b.ToTable("SubContractor_Master");
                });

            modelBuilder.Entity("Benaa2018.Data.Model.ToDoMaster", b =>
                {
                    b.Property<int>("Todo_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AssignTo");

                    b.Property<DateTime>("Assign_Date");

                    b.Property<string>("Created_By");

                    b.Property<DateTime>("Created_Date");

                    b.Property<int>("Days");

                    b.Property<DateTime>("Due_Date_Selection");

                    b.Property<string>("Modified_By");

                    b.Property<DateTime>("Modified_Date");

                    b.Property<string>("Note");

                    b.Property<int>("Org_ID");

                    b.Property<string>("Priority");

                    b.Property<int>("Project_ID");

                    b.Property<string>("Project_Site");

                    b.Property<int>("Reminder_ID");

                    b.Property<int>("Schedule_ID");

                    b.Property<int>("TaG_ID");

                    b.Property<int>("Time_choosen_ID");

                    b.Property<string>("Title");

                    b.Property<string>("state_val");

                    b.HasKey("Todo_ID");

                    b.ToTable("To_Do_Master");
                });

            modelBuilder.Entity("Benaa2018.Data.Model.UserMaster", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Created_By");

                    b.Property<DateTime>("Created_Date");

                    b.Property<string>("FullName");

                    b.Property<string>("Modified_By");

                    b.Property<DateTime>("Modified_Date");

                    b.Property<int>("Org_ID");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("UserID");

                    b.ToTable("User_Master");
                });

            modelBuilder.Entity("Benaa2018.Data.Model.WarrentyAlert", b =>
                {
                    b.Property<int>("Warrent_Alert_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Created_By");

                    b.Property<DateTime>("Created_Date");

                    b.Property<string>("Modified_By");

                    b.Property<DateTime>("Modified_Date");

                    b.Property<int>("User_ID");

                    b.Property<string>("Warrenty_Name");

                    b.Property<int>("Warrenty_Year");

                    b.HasKey("Warrent_Alert_Id");

                    b.ToTable("Warrenty_Alert");
                });
#pragma warning restore 612, 618
        }
    }
}
