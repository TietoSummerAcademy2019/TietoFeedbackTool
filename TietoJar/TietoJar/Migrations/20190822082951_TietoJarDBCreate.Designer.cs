﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TietoJar.Persistence;

namespace TietoJar.Migrations
{
    [DbContext(typeof(TietoJarContext))]
    [Migration("20190822082951_TietoJarDBCreate")]
    partial class TietoJarDBCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TietoJar.Domain.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("TietoJar.Domain.ClosePuzzlePossibility", b =>
                {
                    b.Property<int>("PuzzleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer");

                    b.Property<int>("Counter");

                    b.Property<int>("Position");

                    b.Property<int?>("SurveyPuzzleId");

                    b.HasKey("PuzzleId");

                    b.HasIndex("SurveyPuzzleId");

                    b.ToTable("ClosePuzzlePossibilities");
                });

            modelBuilder.Entity("TietoJar.Domain.OpenPuzzleAnswer", b =>
                {
                    b.Property<int>("PuzzleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.Property<int?>("SurveyPuzzleId");

                    b.HasKey("PuzzleId");

                    b.HasIndex("SurveyPuzzleId");

                    b.ToTable("OpenPuzzleAnswers");
                });

            modelBuilder.Entity("TietoJar.Domain.PuzzleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("HaveOpenAnswer");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PuzzleTypes");
                });

            modelBuilder.Entity("TietoJar.Domain.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<string>("SurveyKey");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("TietoJar.Domain.SurveyPuzzle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Position");

                    b.Property<string>("PuzzleQuestion");

                    b.Property<int>("PuzzleTypeId");

                    b.Property<int>("SurveyId");

                    b.HasKey("Id");

                    b.HasIndex("PuzzleTypeId");

                    b.HasIndex("SurveyId");

                    b.ToTable("SurveyPuzzles");
                });

            modelBuilder.Entity("TietoJar.Domain.ClosePuzzlePossibility", b =>
                {
                    b.HasOne("TietoJar.Domain.SurveyPuzzle")
                        .WithMany("ClosePuzzlePossibilities")
                        .HasForeignKey("SurveyPuzzleId");
                });

            modelBuilder.Entity("TietoJar.Domain.OpenPuzzleAnswer", b =>
                {
                    b.HasOne("TietoJar.Domain.SurveyPuzzle")
                        .WithMany("OpenPuzzleAnswers")
                        .HasForeignKey("SurveyPuzzleId");
                });

            modelBuilder.Entity("TietoJar.Domain.Survey", b =>
                {
                    b.HasOne("TietoJar.Domain.Account")
                        .WithMany("Surveys")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TietoJar.Domain.SurveyPuzzle", b =>
                {
                    b.HasOne("TietoJar.Domain.PuzzleType")
                        .WithMany("SurveyPuzzles")
                        .HasForeignKey("PuzzleTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TietoJar.Domain.Survey")
                        .WithMany("SurveyPuzzles")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
