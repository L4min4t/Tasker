﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tasker.Infrastructure.Data.Application;

#nullable disable

namespace Tasker.Infrastructure.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231217201214_LinkProjectsToUsers")]
    partial class LinkProjectsToUsers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tasker.Domain.Entities.Application.AdminProjectUser", b =>
                {
                    b.Property<string>("ProjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ProjectId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("AdminProjectUser");
                });

            modelBuilder.Entity("Tasker.Domain.Entities.Application.AssignedProjectUser", b =>
                {
                    b.Property<string>("ProjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ProjectId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("AssignedProjectUser");
                });

            modelBuilder.Entity("Tasker.Domain.Entities.Application.KanbanBoard", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProjectId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("KanbanBoards");
                });

            modelBuilder.Entity("Tasker.Domain.Entities.Application.Project", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Tasker.Domain.Entities.Application.Release", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsReleased")
                        .HasColumnType("bit");

                    b.Property<string>("ProjectId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CreationDate");

                    b.HasIndex("ProjectId");

                    b.ToTable("Releases");
                });

            modelBuilder.Entity("Tasker.Domain.Entities.Application.Task", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AssigneeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("ProjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ReleaseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TaskStatusId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("CreationDate");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("ReleaseId");

                    b.HasIndex("TaskStatusId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Tasker.Domain.Entities.Application.TaskStatus", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("KanbanBoardId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KanbanBoardId");

                    b.ToTable("TaskStatuses");
                });

            modelBuilder.Entity("Tasker.Domain.Entities.Application.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Tasker.Domain.Entities.Application.AdminProjectUser", b =>
                {
                    b.HasOne("Tasker.Domain.Entities.Application.Project", "Project")
                        .WithMany("AdminProjectUsers")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasker.Domain.Entities.Application.User", "User")
                        .WithMany("AdminProjectUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tasker.Domain.Entities.Application.AssignedProjectUser", b =>
                {
                    b.HasOne("Tasker.Domain.Entities.Application.Project", "Project")
                        .WithMany("AssignedProjectUsers")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasker.Domain.Entities.Application.User", "User")
                        .WithMany("AssignedProjectUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tasker.Domain.Entities.Application.KanbanBoard", b =>
                {
                    b.HasOne("Tasker.Domain.Entities.Application.Project", "Project")
                        .WithMany("KanbanBoards")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Tasker.Domain.Entities.Application.Release", b =>
                {
                    b.HasOne("Tasker.Domain.Entities.Application.Project", "Project")
                        .WithMany("Releases")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Tasker.Domain.Entities.Application.Task", b =>
                {
                    b.HasOne("Tasker.Domain.Entities.Application.User", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeId");

                    b.HasOne("Tasker.Domain.Entities.Application.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasker.Domain.Entities.Application.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId");

                    b.HasOne("Tasker.Domain.Entities.Application.Release", "Release")
                        .WithMany("Tasks")
                        .HasForeignKey("ReleaseId");

                    b.HasOne("Tasker.Domain.Entities.Application.TaskStatus", "Status")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskStatusId");

                    b.Navigation("Assignee");

                    b.Navigation("Creator");

                    b.Navigation("Project");

                    b.Navigation("Release");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Tasker.Domain.Entities.Application.TaskStatus", b =>
                {
                    b.HasOne("Tasker.Domain.Entities.Application.KanbanBoard", "KanbanBoard")
                        .WithMany("Columns")
                        .HasForeignKey("KanbanBoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KanbanBoard");
                });

            modelBuilder.Entity("Tasker.Domain.Entities.Application.KanbanBoard", b =>
                {
                    b.Navigation("Columns");
                });

            modelBuilder.Entity("Tasker.Domain.Entities.Application.Project", b =>
                {
                    b.Navigation("AdminProjectUsers");

                    b.Navigation("AssignedProjectUsers");

                    b.Navigation("KanbanBoards");

                    b.Navigation("Releases");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Tasker.Domain.Entities.Application.Release", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Tasker.Domain.Entities.Application.TaskStatus", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Tasker.Domain.Entities.Application.User", b =>
                {
                    b.Navigation("AdminProjectUsers");

                    b.Navigation("AssignedProjectUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
