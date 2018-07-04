using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Benaa2018.Data.Migrations
{
    public partial class SBSNew1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Project_Master",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Project_Master",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Project_Master");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Project_Master");
        }
    }
}
