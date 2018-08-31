using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Benaa2018.Data.Migrations
{
    public partial class www : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

           

            

            

            migrationBuilder.CreateTable(
                name: "To_Do_Assign",
                columns: table => new
                {
                    ToDoAssignID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    DeletionStatus = table.Column<bool>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    ToDoUserAssignTypeId = table.Column<int>(nullable: false),
                    TodoDetailsID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_To_Do_Assign", x => x.ToDoAssignID);
                });

            migrationBuilder.CreateTable(
                name: "To_Do_CheckList",
                columns: table => new
                {
                    ToDoCheckListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    DeletionStatus = table.Column<bool>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    ToDoAssignIFilesCheckListItem = table.Column<bool>(nullable: false),
                    ToDoAssignIsCheckListItem = table.Column<bool>(nullable: false),
                    TodoDetailsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_To_Do_CheckList", x => x.ToDoCheckListId);
                });

            migrationBuilder.CreateTable(
                name: "To_Do_CheckList_Details",
                columns: table => new
                {
                    ToDochecklistDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    DeletionStatus = table.Column<bool>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    ToDoCheckListId = table.Column<int>(nullable: false),
                    ToDoCheckListTitle = table.Column<string>(nullable: true),
                    ToDoCheckListUserId = table.Column<int>(nullable: false),
                    ToDoCheckListUserTypeId = table.Column<int>(nullable: false),
                    ToDoIsCheckList = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_To_Do_CheckList_Details", x => x.ToDochecklistDetailsId);
                });

            

           

            migrationBuilder.CreateTable(
                name: "To_Do_Tag",
                columns: table => new
                {
                    ToDoTagid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    DeletionStatus = table.Column<bool>(nullable: false),
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
                name: "To_Do_Assign");

            migrationBuilder.DropTable(
                name: "To_Do_CheckList");

            migrationBuilder.DropTable(
                name: "To_Do_CheckList_Details");

           
            

            migrationBuilder.DropTable(
                name: "To_Do_Tag");

          
        }
    }
}
