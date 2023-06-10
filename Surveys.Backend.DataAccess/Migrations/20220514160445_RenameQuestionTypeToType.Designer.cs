﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Surveys.Backend.DataAccess;

#nullable disable

namespace Surveys.Backend.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220514160445_RenameQuestionTypeToType")]
    partial class RenameQuestionTypeToType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Surveys.Backend.DomainModel.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("QuestionnaireResultId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("SelectedOptionsIds")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("QuestionnaireResultId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Surveys.Backend.DomainModel.Option", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Options");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3d55bb8d-d042-4cc4-9423-994e21141308"),
                            Content = "Option content 1",
                            Order = 1,
                            QuestionId = new Guid("03ec14a4-586c-4f84-9a46-ecb36af457ab")
                        },
                        new
                        {
                            Id = new Guid("bd56f9e1-6b78-4a30-858b-f18ff91b967f"),
                            Content = "Option content 2",
                            Order = 2,
                            QuestionId = new Guid("03ec14a4-586c-4f84-9a46-ecb36af457ab")
                        },
                        new
                        {
                            Id = new Guid("ab39b4ae-8f88-4604-b4ba-911d59b61cb9"),
                            Content = "Option content 3",
                            Order = 3,
                            QuestionId = new Guid("03ec14a4-586c-4f84-9a46-ecb36af457ab")
                        });
                });

            modelBuilder.Entity("Surveys.Backend.DomainModel.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRequired")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<Guid>("QuestionnaireId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionnaireId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("03ec14a4-586c-4f84-9a46-ecb36af457ab"),
                            Description = "Text Question description",
                            IsRequired = true,
                            Order = 1,
                            QuestionnaireId = new Guid("48bd6426-f2bc-4c04-a15d-25eb88d6fb67"),
                            Title = "Question title 1",
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("cb22e35c-5360-4f91-b66b-f139fdfaf3f7"),
                            Description = "Text Question description",
                            IsRequired = true,
                            Order = 2,
                            QuestionnaireId = new Guid("48bd6426-f2bc-4c04-a15d-25eb88d6fb67"),
                            Title = "Question title 2",
                            Type = 1
                        });
                });

            modelBuilder.Entity("Surveys.Backend.DomainModel.Questionnaire", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RegisteredOnly")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid?>("UpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("UpdatedById");

                    b.ToTable("Questionnaires");

                    b.HasData(
                        new
                        {
                            Id = new Guid("48bd6426-f2bc-4c04-a15d-25eb88d6fb67"),
                            CreatedById = new Guid("670c28b5-0731-4334-866b-0fb107bf7a31"),
                            Description = "Questionnaire description",
                            RegisteredOnly = false,
                            Title = "Questionnaire title",
                            UpdatedById = new Guid("670c28b5-0731-4334-866b-0fb107bf7a31")
                        });
                });

            modelBuilder.Entity("Surveys.Backend.DomainModel.QuestionnaireResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PassedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuestionnaireId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PassedById");

                    b.ToTable("QuestionnaireResults");
                });

            modelBuilder.Entity("Surveys.Backend.DomainModel.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3e4ba5e7-073e-4805-bb2d-e14986a97a0a"),
                            ConcurrencyStamp = "7f6a67ba-4476-4e3a-b083-894568a74108",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("f38d3fa7-4ebd-4759-8532-d0cfdc818ae8"),
                            ConcurrencyStamp = "60e9d83e-a12e-486a-86fa-ca5a00a30ba6",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Surveys.Backend.DomainModel.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("670c28b5-0731-4334-866b-0fb107bf7a31"),
                            ConcurrencyStamp = "e791a2a4-a047-4bb8-ade4-bb057d64402b",
                            Email = "admin@admin.com",
                            Name = "Admin name",
                            PasswordHash = "AQAAAAEAACcQAAAAEG7GjGscVhfXF8pAiPIYvEITHNxVf79m+Qz0Bjfwj+PJETeuYWGyHsfs/1MLrFoqBw=="
                        });
                });

            modelBuilder.Entity("Surveys.Backend.DomainModel.Answer", b =>
                {
                    b.HasOne("Surveys.Backend.DomainModel.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Surveys.Backend.DomainModel.QuestionnaireResult", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionnaireResultId");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Surveys.Backend.DomainModel.Option", b =>
                {
                    b.HasOne("Surveys.Backend.DomainModel.Question", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Surveys.Backend.DomainModel.Question", b =>
                {
                    b.HasOne("Surveys.Backend.DomainModel.Questionnaire", "Questionnaire")
                        .WithMany("Questions")
                        .HasForeignKey("QuestionnaireId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Questionnaire");
                });

            modelBuilder.Entity("Surveys.Backend.DomainModel.Questionnaire", b =>
                {
                    b.HasOne("Surveys.Backend.DomainModel.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Surveys.Backend.DomainModel.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("Surveys.Backend.DomainModel.QuestionnaireResult", b =>
                {
                    b.HasOne("Surveys.Backend.DomainModel.User", "PassedBy")
                        .WithMany()
                        .HasForeignKey("PassedById");

                    b.Navigation("PassedBy");
                });

            modelBuilder.Entity("Surveys.Backend.DomainModel.Role", b =>
                {
                    b.HasOne("Surveys.Backend.DomainModel.User", null)
                        .WithMany("Roles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Surveys.Backend.DomainModel.Question", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("Surveys.Backend.DomainModel.Questionnaire", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Surveys.Backend.DomainModel.QuestionnaireResult", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Surveys.Backend.DomainModel.User", b =>
                {
                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}