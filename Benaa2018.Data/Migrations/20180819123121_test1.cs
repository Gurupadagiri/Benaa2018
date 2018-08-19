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
                name: "Activity_Master",
                columns: table => new
                {
                    Activity_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Activity_Name = table.Column<string>(nullable: true),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Is_Deleted = table.Column<bool>(nullable: false),
                    Main_Activity_Id = table.Column<int>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    Org_Id = table.Column<int>(nullable: false),
                    Parent_Id = table.Column<int>(nullable: false),
                    Sequence = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity_Master", x => x.Activity_Id);
                });

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity_Master");

           
        }
    }
}
