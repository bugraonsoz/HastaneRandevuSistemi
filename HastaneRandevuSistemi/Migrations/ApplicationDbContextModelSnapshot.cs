﻿// <auto-generated />
using System;
using HastaneRandevuSistemi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HastaneRandevuSistemi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentId"));

                    b.Property<int>("AssistantId")
                        .HasColumnType("int");

                    b.Property<int?>("CalendarViewModelId")
                        .HasColumnType("int");

                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ShiftDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TimeSlot")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AppointmentId");

                    b.HasIndex("AssistantId");

                    b.HasIndex("CalendarViewModelId");

                    b.HasIndex("InstructorId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.AppointmentInfos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AssistantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssistantTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstructorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstructorTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MeetDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TimeSlot")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("appointmentInfos");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Assistant", b =>
                {
                    b.Property<int>("AssistantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssistantID"));

                    b.Property<int?>("CalendarViewModelId")
                        .HasColumnType("int");

                    b.Property<int?>("DepAsInsId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssistantID");

                    b.HasIndex("CalendarViewModelId");

                    b.HasIndex("DepAsInsId");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Assistants");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.AssistantShiftViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DepartmentDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ShiftDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShiftDuration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AssistantShiftViewModel");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.CalendarViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("calendarViewModels");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.DepAsIns", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("DepAsInss");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("CurrentPatient")
                        .HasColumnType("int");

                    b.Property<int?>("DepAsInsId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.HasIndex("DepAsInsId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Emergency", b =>
                {
                    b.Property<int>("ShiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShiftId"));

                    b.Property<int?>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShiftId");

                    b.ToTable("Emergencies");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Instructor", b =>
                {
                    b.Property<int>("InstructorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstructorID"));

                    b.Property<int?>("CalendarViewModelId")
                        .HasColumnType("int");

                    b.Property<int?>("DepAsInsId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstructorID");

                    b.HasIndex("CalendarViewModelId");

                    b.HasIndex("DepAsInsId");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Shift", b =>
                {
                    b.Property<int>("ShiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShiftId"));

                    b.Property<int>("AssistantId")
                        .HasColumnType("int");

                    b.Property<int?>("CalendarViewModelId")
                        .HasColumnType("int");

                    b.Property<int?>("DepAsInsId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ShiftDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShiftDuration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShiftId");

                    b.HasIndex("AssistantId");

                    b.HasIndex("CalendarViewModelId");

                    b.HasIndex("DepAsInsId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Appointment", b =>
                {
                    b.HasOne("HastaneRandevuSistemi.Models.Assistant", "Assistant")
                        .WithMany("Appointments")
                        .HasForeignKey("AssistantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneRandevuSistemi.Models.CalendarViewModel", null)
                        .WithMany("Appointments")
                        .HasForeignKey("CalendarViewModelId");

                    b.HasOne("HastaneRandevuSistemi.Models.Instructor", "Instructor")
                        .WithMany("Appointments")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assistant");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Assistant", b =>
                {
                    b.HasOne("HastaneRandevuSistemi.Models.CalendarViewModel", null)
                        .WithMany("Assistants")
                        .HasForeignKey("CalendarViewModelId");

                    b.HasOne("HastaneRandevuSistemi.Models.DepAsIns", null)
                        .WithMany("Assistants")
                        .HasForeignKey("DepAsInsId");

                    b.HasOne("HastaneRandevuSistemi.Models.Department", "Department")
                        .WithMany("Assistants")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Department", b =>
                {
                    b.HasOne("HastaneRandevuSistemi.Models.DepAsIns", null)
                        .WithMany("Departments")
                        .HasForeignKey("DepAsInsId");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Instructor", b =>
                {
                    b.HasOne("HastaneRandevuSistemi.Models.CalendarViewModel", null)
                        .WithMany("Instructors")
                        .HasForeignKey("CalendarViewModelId");

                    b.HasOne("HastaneRandevuSistemi.Models.DepAsIns", null)
                        .WithMany("Instructors")
                        .HasForeignKey("DepAsInsId");

                    b.HasOne("HastaneRandevuSistemi.Models.Department", "Department")
                        .WithMany("Instructors")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Shift", b =>
                {
                    b.HasOne("HastaneRandevuSistemi.Models.Assistant", "Assistant")
                        .WithMany("Shifts")
                        .HasForeignKey("AssistantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneRandevuSistemi.Models.CalendarViewModel", null)
                        .WithMany("Shifts")
                        .HasForeignKey("CalendarViewModelId");

                    b.HasOne("HastaneRandevuSistemi.Models.DepAsIns", null)
                        .WithMany("Shifts")
                        .HasForeignKey("DepAsInsId");

                    b.HasOne("HastaneRandevuSistemi.Models.Department", "Department")
                        .WithMany("Shifts")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assistant");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.User", b =>
                {
                    b.HasOne("HastaneRandevuSistemi.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Assistant", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Shifts");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.CalendarViewModel", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Assistants");

                    b.Navigation("Instructors");

                    b.Navigation("Shifts");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.DepAsIns", b =>
                {
                    b.Navigation("Assistants");

                    b.Navigation("Departments");

                    b.Navigation("Instructors");

                    b.Navigation("Shifts");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Department", b =>
                {
                    b.Navigation("Assistants");

                    b.Navigation("Instructors");

                    b.Navigation("Shifts");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Instructor", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
