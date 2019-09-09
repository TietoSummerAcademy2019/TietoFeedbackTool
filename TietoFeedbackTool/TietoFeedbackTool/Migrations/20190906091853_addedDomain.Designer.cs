﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TietoFeedbackTool.Persistence;

namespace TietoFeedbackTool.Migrations
{
    [DbContext(typeof(TietoFeedbackToolContext))]
    [Migration("20190906091853_addedDomain")]
    partial class addedDomain
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TietoFeedbackTool.Domain.Account", b =>
                {
                    b.Property<string>("Login")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("Login");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("TietoFeedbackTool.Domain.ClosePuzzleAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClosePuzzlePossibilityId");

                    b.Property<DateTime>("SubmitDate")
                        .HasColumnType("Date");

                    b.HasKey("Id");

                    b.HasIndex("ClosePuzzlePossibilityId");

                    b.ToTable("ClosePuzzleAnswers");
                });

            modelBuilder.Entity("TietoFeedbackTool.Domain.ClosePuzzlePossibility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer");

                    b.Property<int>("Counter");

                    b.Property<int>("Position");

                    b.Property<int>("SurveyPuzzleId");

                    b.HasKey("Id");

                    b.HasIndex("SurveyPuzzleId");

                    b.ToTable("ClosePuzzlePossibilities");
                });

            modelBuilder.Entity("TietoFeedbackTool.Domain.OpenPuzzleAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.Property<DateTime>("SubmitDate")
                        .HasColumnType("Datetime");

                    b.Property<int>("SurveyPuzzleId");

                    b.HasKey("Id");

                    b.HasIndex("SurveyPuzzleId");

                    b.ToTable("OpenPuzzleAnswers");
                });

            modelBuilder.Entity("TietoFeedbackTool.Domain.PuzzleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("HaveOpenAnswer");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PuzzleTypes");
                });

            modelBuilder.Entity("TietoFeedbackTool.Domain.Survey", b =>
                {
                    b.Property<string>("SurveyKey")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountLogin");

                    b.Property<string>("Domain");

                    b.Property<string>("Name");

                    b.HasKey("SurveyKey");

                    b.HasIndex("AccountLogin");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("TietoFeedbackTool.Domain.SurveyPuzzle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Position");

                    b.Property<string>("PuzzleQuestion");

                    b.Property<int>("PuzzleTypeId");

                    b.Property<string>("SurveyKey");

                    b.HasKey("Id");

                    b.HasIndex("PuzzleTypeId");

                    b.HasIndex("SurveyKey");

                    b.ToTable("SurveyPuzzles");
                });

            modelBuilder.Entity("TietoFeedbackTool.Domain.ClosePuzzleAnswer", b =>
                {
                    b.HasOne("TietoFeedbackTool.Domain.ClosePuzzlePossibility")
                        .WithMany("ClosePuzzleAnswers")
                        .HasForeignKey("ClosePuzzlePossibilityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TietoFeedbackTool.Domain.ClosePuzzlePossibility", b =>
                {
                    b.HasOne("TietoFeedbackTool.Domain.SurveyPuzzle")
                        .WithMany("ClosePuzzlePossibilities")
                        .HasForeignKey("SurveyPuzzleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TietoFeedbackTool.Domain.OpenPuzzleAnswer", b =>
                {
                    b.HasOne("TietoFeedbackTool.Domain.SurveyPuzzle")
                        .WithMany("OpenPuzzleAnswers")
                        .HasForeignKey("SurveyPuzzleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TietoFeedbackTool.Domain.Survey", b =>
                {
                    b.HasOne("TietoFeedbackTool.Domain.Account")
                        .WithMany("Surveys")
                        .HasForeignKey("AccountLogin");
                });

            modelBuilder.Entity("TietoFeedbackTool.Domain.SurveyPuzzle", b =>
                {
                    b.HasOne("TietoFeedbackTool.Domain.PuzzleType")
                        .WithMany("SurveyPuzzles")
                        .HasForeignKey("PuzzleTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TietoFeedbackTool.Domain.Survey")
                        .WithMany("SurveyPuzzles")
                        .HasForeignKey("SurveyKey");
                });
#pragma warning restore 612, 618
        }
    }
}
