using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Benaa2018.Data.Migrations
{
    public partial class SBSNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company_Master",
                columns: table => new
                {
                    Org_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Company_Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company_Master", x => x.Org_ID);
                });

            migrationBuilder.CreateTable(
                name: "Login_Details_Info",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastLoginDate = table.Column<DateTime>(nullable: false),
                    LoginDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login_Details_Info", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Menu_Master",
                columns: table => new
                {
                    Menu_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    CssClass = table.Column<string>(nullable: true),
                    Delflag = table.Column<bool>(nullable: false),
                    Menu_Name = table.Column<string>(nullable: true),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    PatentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_Master", x => x.Menu_ID);
                });

            migrationBuilder.CreateTable(
                name: "Owner_Master",
                columns: table => new
                {
                    Owner_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessMethod = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    AllowLockedSelections = table.Column<bool>(nullable: false),
                    AllowOrderRequests = table.Column<bool>(nullable: false),
                    AllowPaymentsTab = table.Column<bool>(nullable: false),
                    AllowWarrantyClaims = table.Column<bool>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Mobile_No = table.Column<string>(nullable: true),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    Org_ID = table.Column<int>(nullable: false),
                    OwnerActivation = table.Column<string>(nullable: true),
                    OwnerCalendar = table.Column<string>(nullable: true),
                    OwnerInformation = table.Column<string>(nullable: true),
                    Owner_Name = table.Column<string>(nullable: true),
                    Profile_Picture = table.Column<string>(nullable: true),
                    Project_ID = table.Column<int>(nullable: false),
                    ShowBudgetPurchaseOrders = table.Column<bool>(nullable: false),
                    ShowProjectPrice = table.Column<bool>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner_Master", x => x.Owner_ID);
                });

            migrationBuilder.CreateTable(
                name: "Project_Color",
                columns: table => new
                {
                    ProjectColorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDisable = table.Column<bool>(nullable: false),
                    ProjectColorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Color", x => x.ProjectColorId);
                });

            migrationBuilder.CreateTable(
                name: "Project_Group",
                columns: table => new
                {
                    Project_Goup_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    Project_Group_Name = table.Column<string>(nullable: true),
                    User_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Group", x => x.Project_Goup_ID);
                });

            migrationBuilder.CreateTable(
                name: "Project_Manager_Master",
                columns: table => new
                {
                    Manager_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Manager_Name = table.Column<string>(nullable: true),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    Org_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Manager_Master", x => x.Manager_ID);
                });

            migrationBuilder.CreateTable(
                name: "Project_Master",
                columns: table => new
                {
                    Project_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Built_Up_Area = table.Column<float>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Contract_Price = table.Column<decimal>(nullable: false),
                    Country_ID = table.Column<decimal>(nullable: false),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Group_No = table.Column<string>(nullable: true),
                    Internal_Notes = table.Column<string>(nullable: true),
                    Lot_Info = table.Column<string>(nullable: true),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    No_Of_Unit = table.Column<int>(nullable: false),
                    Org_ID = table.Column<long>(nullable: false),
                    Permit_No = table.Column<string>(nullable: true),
                    Project_Group_ID = table.Column<string>(nullable: true),
                    Project_Manager_id = table.Column<string>(nullable: true),
                    Project_Name = table.Column<string>(nullable: true),
                    Project_Prefix = table.Column<string>(nullable: true),
                    Project_Type_ID = table.Column<int>(nullable: false),
                    Project_land_Cost = table.Column<float>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    Status_ID = table.Column<int>(nullable: false),
                    Sub_Notes = table.Column<string>(nullable: true),
                    User_ID = table.Column<int>(nullable: false),
                    Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Master", x => x.Project_ID);
                });

            migrationBuilder.CreateTable(
                name: "Project_schedule_Master",
                columns: table => new
                {
                    Schedule_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Actual_Completion = table.Column<DateTime>(nullable: false),
                    Actual_Start = table.Column<DateTime>(nullable: false),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    Org_ID = table.Column<int>(nullable: false),
                    ProjectColorId = table.Column<int>(nullable: false),
                    Project_Color_ID = table.Column<int>(nullable: false),
                    Project_ID = table.Column<int>(nullable: false),
                    Projected_Completion = table.Column<DateTime>(nullable: false),
                    Projected_Start = table.Column<DateTime>(nullable: false),
                    Works_Days = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_schedule_Master", x => x.Schedule_ID);
                });

            migrationBuilder.CreateTable(
                name: "Project_Status_Master",
                columns: table => new
                {
                    Status_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    Org_ID = table.Column<int>(nullable: false),
                    Status_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Status_Master", x => x.Status_ID);
                });

            migrationBuilder.CreateTable(
                name: "Project_Subcontractor_config",
                columns: table => new
                {
                    SubContractor_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    Org_ID = table.Column<int>(nullable: false),
                    Project_ID = table.Column<decimal>(nullable: false),
                    Subcontractor_Name = table.Column<string>(nullable: true),
                    View_Access = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Subcontractor_config", x => x.SubContractor_ID);
                });

            migrationBuilder.CreateTable(
                name: "Project_Type_Master",
                columns: table => new
                {
                    Project_Type_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    Org_ID = table.Column<int>(nullable: false),
                    Project_Type_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Type_Master", x => x.Project_Type_ID);
                });

            migrationBuilder.CreateTable(
                name: "Project_User_Int_Config_Master",
                columns: table => new
                {
                    Internal_User_Con_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Org_ID = table.Column<int>(nullable: false),
                    Project_ID = table.Column<int>(nullable: false),
                    Recive_Notification = table.Column<bool>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    User_Name = table.Column<string>(nullable: true),
                    View_Access = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_User_Int_Config_Master", x => x.Internal_User_Con_Id);
                });

            migrationBuilder.CreateTable(
                name: "SubContractor_Master",
                columns: table => new
                {
                    SubContractor_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Beneficiary = table.Column<string>(nullable: true),
                    CR_NO = table.Column<string>(nullable: true),
                    Catogery_ID = table.Column<decimal>(nullable: false),
                    Contact_Persion = table.Column<string>(nullable: true),
                    Country_ID = table.Column<int>(nullable: false),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Org_ID = table.Column<int>(nullable: false),
                    Tel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubContractor_Master", x => x.SubContractor_ID);
                });

            migrationBuilder.CreateTable(
                name: "To_Do_Master",
                columns: table => new
                {
                    Todo_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssignTo = table.Column<string>(nullable: true),
                    Assign_Date = table.Column<DateTime>(nullable: false),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Days = table.Column<int>(nullable: false),
                    Due_Date_Selection = table.Column<DateTime>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Org_ID = table.Column<int>(nullable: false),
                    Priority = table.Column<string>(nullable: true),
                    Project_ID = table.Column<int>(nullable: false),
                    Project_Site = table.Column<string>(nullable: true),
                    Reminder_ID = table.Column<int>(nullable: false),
                    Schedule_ID = table.Column<int>(nullable: false),
                    TaG_ID = table.Column<int>(nullable: false),
                    Time_choosen_ID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    state_val = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_To_Do_Master", x => x.Todo_ID);
                });

            migrationBuilder.CreateTable(
                name: "User_Master",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    Org_ID = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Master", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Warrenty_Alert",
                columns: table => new
                {
                    Warrent_Alert_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    User_ID = table.Column<int>(nullable: false),
                    Warrenty_Name = table.Column<string>(nullable: true),
                    Warrenty_Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warrenty_Alert", x => x.Warrent_Alert_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company_Master");

            migrationBuilder.DropTable(
                name: "Login_Details_Info");

            migrationBuilder.DropTable(
                name: "Menu_Master");

            migrationBuilder.DropTable(
                name: "Owner_Master");

            migrationBuilder.DropTable(
                name: "Project_Color");

            migrationBuilder.DropTable(
                name: "Project_Group");

            migrationBuilder.DropTable(
                name: "Project_Manager_Master");

            migrationBuilder.DropTable(
                name: "Project_Master");

            migrationBuilder.DropTable(
                name: "Project_schedule_Master");

            migrationBuilder.DropTable(
                name: "Project_Status_Master");

            migrationBuilder.DropTable(
                name: "Project_Subcontractor_config");

            migrationBuilder.DropTable(
                name: "Project_Type_Master");

            migrationBuilder.DropTable(
                name: "Project_User_Int_Config_Master");

            migrationBuilder.DropTable(
                name: "SubContractor_Master");

            migrationBuilder.DropTable(
                name: "To_Do_Master");

            migrationBuilder.DropTable(
                name: "User_Master");

            migrationBuilder.DropTable(
                name: "Warrenty_Alert");
        }
    }
}
