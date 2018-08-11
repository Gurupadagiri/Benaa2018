using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Benaa2018.Data.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "To_Do_Master_Details",
                columns: table => new
                {
                    TodoDetailsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    DeletionStatus = table.Column<bool>(nullable: false),
                    DueDatetime = table.Column<string>(nullable: true),
                    Duedate = table.Column<DateTime>(nullable: false),
                    IsMarkedComplete = table.Column<bool>(nullable: false),
                    LinkToDate = table.Column<DateTime>(nullable: false),
                    LinkToDaysStatus = table.Column<string>(nullable: true),
                    LinkToTime = table.Column<string>(nullable: true),
                    LinkToUnit = table.Column<int>(nullable: false),
                    LinkToWorkId = table.Column<int>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    Org_ID = table.Column<int>(nullable: false),
                    Priority = table.Column<string>(nullable: true),
                    Project_ID = table.Column<int>(nullable: false),
                    Project_Site = table.Column<string>(nullable: true),
                    ReminderId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    TypeNote = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_To_Do_Master_Details", x => x.TodoDetailsID);
                });

            migrationBuilder.CreateTable(
                name: "To_Do_Tag",
                columns: table => new
                {
                    ToDoTagid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    Tagid = table.Column<int>(nullable: false),
                    TodoDetailsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_To_Do_Tag", x => x.ToDoTagid);
                });

           

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calendar_Scheduled_Item");

            migrationBuilder.DropTable(
                name: "Company_Master");

            migrationBuilder.DropTable(
                name: "Detaild_Permission");

            migrationBuilder.DropTable(
                name: "Login_Details_Info");

            migrationBuilder.DropTable(
                name: "Menu_Master");

            migrationBuilder.DropTable(
                name: "Owner_Master");

            migrationBuilder.DropTable(
                name: "Predecessor_Information");

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
                name: "Tag_Master");

            migrationBuilder.DropTable(
                name: "To_Do_Master");

            migrationBuilder.DropTable(
                name: "To_Do_Master_Details");

            migrationBuilder.DropTable(
                name: "To_Do_Tag");

            migrationBuilder.DropTable(
                name: "User_Master");

            migrationBuilder.DropTable(
                name: "Warrenty_Alert");
        }
    }
}
