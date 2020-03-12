﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestTechnique.Data;

namespace TestTechnique.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200312161804_Ids")]
    partial class Ids
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TestTechnique.Models.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatorId");

                    b.Property<string>("OriginalLink");

                    b.Property<string>("ShortLink");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("TestTechnique.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Pwd");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TestTechnique.Models.Link", b =>
                {
                    b.HasOne("TestTechnique.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
