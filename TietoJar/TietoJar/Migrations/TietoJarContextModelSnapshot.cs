﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TietoJar.Persistence;

namespace TietoJar.Migrations
{
    [DbContext(typeof(TietoJarContext))]
    partial class TietoJarContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TietoJar.Domain.Account", b =>
                {
                    b.Property<string>("Login")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("Login");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("TietoJar.Domain.ClosePuzzleAnswer", b =>
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

            modelBuilder.Entity("TietoJar.Domain.ClosePuzzlePossibility", b =>
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

            modelBuilder.Entity("TietoJar.Domain.OpenPuzzleAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.Property<int>("SurveyPuzzleId");

                    b.HasKey("Id");

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
                    b.Property<string>("SurveyKey")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountLogin");

                    b.Property<string>("Name");

                    b.HasKey("SurveyKey");

                    b.HasIndex("AccountLogin");

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

                    b.Property<string>("SurveyKey");

                    b.HasKey("Id");

                    b.HasIndex("PuzzleTypeId");

                    b.HasIndex("SurveyKey");

                    b.ToTable("SurveyPuzzles");
                });

            modelBuilder.Entity("TietoJar.Domain.ClosePuzzleAnswer", b =>
                {
                    b.HasOne("TietoJar.Domain.ClosePuzzlePossibility")
                        .WithMany("ClosePuzzleAnswers")
                        .HasForeignKey("ClosePuzzlePossibilityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TietoJar.Domain.ClosePuzzlePossibility", b =>
                {
                    b.HasOne("TietoJar.Domain.SurveyPuzzle")
                        .WithMany("ClosePuzzlePossibilities")
                        .HasForeignKey("SurveyPuzzleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TietoJar.Domain.OpenPuzzleAnswer", b =>
                {
                    b.HasOne("TietoJar.Domain.SurveyPuzzle")
                        .WithMany("OpenPuzzleAnswers")
                        .HasForeignKey("SurveyPuzzleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TietoJar.Domain.Survey", b =>
                {
                    b.HasOne("TietoJar.Domain.Account")
                        .WithMany("Surveys")
                        .HasForeignKey("AccountLogin");
                });

            modelBuilder.Entity("TietoJar.Domain.SurveyPuzzle", b =>
                {
                    b.HasOne("TietoJar.Domain.PuzzleType")
                        .WithMany("SurveyPuzzles")
                        .HasForeignKey("PuzzleTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TietoJar.Domain.Survey")
                        .WithMany("SurveyPuzzles")
                        .HasForeignKey("SurveyKey");
                });
#pragma warning restore 612, 618
        }
    }
}
