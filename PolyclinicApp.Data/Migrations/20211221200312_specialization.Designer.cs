﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PolyclinicApp.Data.DataAccess;

#nullable disable

namespace PolyclinicApp.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211221200312_specialization")]
    partial class specialization
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("SQL_Latin1_General_CP1_CS_AS")
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PolyclinicApp.Data.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorId"), 1L, 1);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpecializationId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DoctorId");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("PolyclinicApp.Data.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientId"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuranceIndividualPersonalAccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MedicalInsuranceId")
                        .HasColumnType("int");

                    b.Property<int>("PassportId")
                        .HasColumnType("int");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientId");

                    b.HasIndex("AddressId");

                    b.HasIndex("MedicalInsuranceId");

                    b.HasIndex("PassportId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("PolyclinicApplication.Data.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("House")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Other")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("PolyclinicApplication.Data.Models.MedicalInsurance", b =>
                {
                    b.Property<int>("MedicalInsuranceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicalInsuranceId"), 1L, 1);

                    b.Property<DateTime>("DateOfIssue")
                        .HasColumnType("datetime2");

                    b.Property<string>("InsuranceCompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("MedicalInsuranceNumber")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.HasKey("MedicalInsuranceId");

                    b.ToTable("MedicalInsurances");
                });

            modelBuilder.Entity("PolyclinicApplication.Data.Models.MedicineCard", b =>
                {
                    b.Property<int>("MedicineCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicineCardId"), 1L, 1);

                    b.Property<DateTime?>("DateOfDiagnosis")
                        .HasColumnType("datetime2");

                    b.Property<string>("Disease")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("MedicineCardId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("MedicineCards");
                });

            modelBuilder.Entity("PolyclinicApplication.Data.Models.Passport", b =>
                {
                    b.Property<int>("PassportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassportId"), 1L, 1);

                    b.Property<string>("PassportCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PassportDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PassportExtraditionPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PassportId");

                    b.ToTable("Passports");
                });

            modelBuilder.Entity("PolyclinicApplication.Data.Models.Reception", b =>
                {
                    b.Property<int>("ReceptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReceptionId"), 1L, 1);

                    b.Property<DateTime>("DateOfAssignment")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("HealthComplaint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("ReceptionId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Receptions");
                });

            modelBuilder.Entity("PolyclinicApplication.Data.Models.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleId"), 1L, 1);

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("Friday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Monday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Saturday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sunday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Thursday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tuesday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wednesday")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ScheduleId");

                    b.HasIndex("DoctorId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("PolyclinicApplication.Data.Models.Specialization", b =>
                {
                    b.Property<int>("SpecializationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpecializationId"), 1L, 1);

                    b.Property<string>("SpecializationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpecializationId");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("PolyclinicApplication.Data.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PolyclinicApp.Data.Models.Doctor", b =>
                {
                    b.HasOne("PolyclinicApplication.Data.Models.Specialization", "Specialization")
                        .WithMany()
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("PolyclinicApp.Data.Models.Patient", b =>
                {
                    b.HasOne("PolyclinicApplication.Data.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PolyclinicApplication.Data.Models.MedicalInsurance", "MedicalInsurance")
                        .WithMany()
                        .HasForeignKey("MedicalInsuranceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PolyclinicApplication.Data.Models.Passport", "Passport")
                        .WithMany()
                        .HasForeignKey("PassportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("MedicalInsurance");

                    b.Navigation("Passport");
                });

            modelBuilder.Entity("PolyclinicApplication.Data.Models.MedicineCard", b =>
                {
                    b.HasOne("PolyclinicApp.Data.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PolyclinicApp.Data.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("PolyclinicApplication.Data.Models.Reception", b =>
                {
                    b.HasOne("PolyclinicApp.Data.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PolyclinicApp.Data.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("PolyclinicApplication.Data.Models.Schedule", b =>
                {
                    b.HasOne("PolyclinicApp.Data.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });
#pragma warning restore 612, 618
        }
    }
}
