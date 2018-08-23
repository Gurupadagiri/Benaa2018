using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Benaa2018.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

     
           
            migrationBuilder.CreateTable(
                name: "To_Do_Message",
                columns: table => new
                {
                    ToDo_Message_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Is_Owner = table.Column<bool>(nullable: false),
                    Is_Sub = table.Column<bool>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    ToDo_Details_Id = table.Column<int>(nullable: false),
                    ToDo_Message_Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_To_Do_Message", x => x.ToDo_Message_Id);
                });

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

           

            migrationBuilder.DropTable(
                name: "To_Do_Message");

            
        }
    }
}
