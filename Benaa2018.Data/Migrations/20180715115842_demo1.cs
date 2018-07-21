using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Benaa2018.Data.Migrations
{
    public partial class demo1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
           
           

            migrationBuilder.CreateTable(
                name: "Project_Color",
                columns: table => new
                {
                    ProjectColorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColorCode = table.Column<string>(nullable: true),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    IsDisable = table.Column<bool>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    ProjectColorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Color", x => x.ProjectColorId);
                });

           
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropTable(
                name: "Project_Color");

           
        }
    }
}
