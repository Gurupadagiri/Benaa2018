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
    partial class SBSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Benaa2018.Data.Model.ActivityMaster", b =>
                {
                    b.Property<int>("Activity_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Activity_Name");

                    b.Property<string>("Created_By");

                    b.Property<DateTime>("Created_Date");

                    b.Property<bool>("Is_Deleted");

                    b.Property<int>("Main_Activity_Id");

                    b.Property<string>("Modified_By");

                    b.Property<DateTime>("Modified_Date");

                    b.Property<int>("Org_Id");

                    b.Property<int>("Parent_Id");

                    b.Property<string>("Sequence");

                    b.Property<bool>("Status");

                    b.HasKey("Activity_Id");

                    b.ToTable("Activity_Master");
                });

            
#pragma warning restore 612, 618
        }
    }
}
