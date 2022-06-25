﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TonerManagement.Data;

#nullable disable

namespace TonerManagement.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Toner.Domain.Entities.CustomerInfo", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("ContactNumber")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("smalldatetime");

                    b.Property<bool?>("IsRowDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("CustomerInfos");
                });

            modelBuilder.Entity("Toner.Domain.Entities.MachineInfo", b =>
                {
                    b.Property<int>("MachineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MachineId"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("smalldatetime");

                    b.Property<bool?>("IsRowDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MachineName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("MachineSI")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("MachineId");

                    b.HasIndex("ProjectId");

                    b.ToTable("MachineInfos");
                });

            modelBuilder.Entity("Toner.Domain.Entities.ProjectInfo", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("ContactNumber")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerInfoCustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("smalldatetime");

                    b.Property<bool?>("IsRowDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ProjectId");

                    b.HasIndex("CustomerInfoCustomerId");

                    b.ToTable("ProjectInfos");
                });

            modelBuilder.Entity("Toner.Domain.Entities.TonerDetail", b =>
                {
                    b.Property<int>("TonerDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TonerDetailId"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CurrentTonerStock")
                        .HasColumnType("float");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("smalldatetime");

                    b.Property<double>("InHouseTotalToner")
                        .HasColumnType("float");

                    b.Property<bool?>("IsRowDeleted")
                        .HasColumnType("bit");

                    b.Property<double>("LastMonthTotalTonerStock")
                        .HasColumnType("float");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MonthlyDeliveryToner")
                        .HasColumnType("float");

                    b.Property<double>("MonthlyUsedToner")
                        .HasColumnType("float");

                    b.Property<double>("TotalMachineToner")
                        .HasColumnType("float");

                    b.Property<double>("TotalTonerStock")
                        .HasColumnType("float");

                    b.Property<int>("UsesDetailId")
                        .HasColumnType("int");

                    b.HasKey("TonerDetailId");

                    b.HasIndex("UsesDetailId");

                    b.ToTable("TonerDetails");
                });

            modelBuilder.Entity("Toner.Domain.Entities.TonerInfo", b =>
                {
                    b.Property<int>("TonerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TonerId"), 1L, 1);

                    b.Property<string>("BW")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CurrentTonerStock")
                        .HasColumnType("float");

                    b.Property<string>("Cyan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("smalldatetime");

                    b.Property<double>("InHouseTotalToner")
                        .HasColumnType("float");

                    b.Property<bool?>("IsRowDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("K")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("LastMonthTotalTonerStock")
                        .HasColumnType("float");

                    b.Property<string>("M")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MonthlyDeliveryToner")
                        .HasColumnType("float");

                    b.Property<double>("MonthlyUsedToner")
                        .HasColumnType("float");

                    b.Property<string>("TonerModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalMachineToner")
                        .HasColumnType("float");

                    b.Property<double>("TotalTonerStock")
                        .HasColumnType("float");

                    b.Property<string>("Y")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TonerId");

                    b.ToTable("TonerInfos");
                });

            modelBuilder.Entity("Toner.Domain.Entities.UsesDetail", b =>
                {
                    b.Property<int>("UsesDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsesDetailId"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CurCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("smalldatetime");

                    b.Property<bool?>("IsRowDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrevCount")
                        .HasColumnType("int");

                    b.Property<int>("TonerPercentage")
                        .HasColumnType("int");

                    b.Property<int>("TotalCount")
                        .HasColumnType("int");

                    b.HasKey("UsesDetailId");

                    b.HasIndex("MachineId");

                    b.ToTable("UsesDetails");
                });

            modelBuilder.Entity("Toner.Domain.Entities.MachineInfo", b =>
                {
                    b.HasOne("Toner.Domain.Entities.ProjectInfo", "ProjectInfo")
                        .WithMany("MachineInfos")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectInfo");
                });

            modelBuilder.Entity("Toner.Domain.Entities.ProjectInfo", b =>
                {
                    b.HasOne("Toner.Domain.Entities.CustomerInfo", "CustomerInfo")
                        .WithMany("ProjectInfos")
                        .HasForeignKey("CustomerInfoCustomerId");

                    b.Navigation("CustomerInfo");
                });

            modelBuilder.Entity("Toner.Domain.Entities.TonerDetail", b =>
                {
                    b.HasOne("Toner.Domain.Entities.UsesDetail", "UsesDetail")
                        .WithMany("TonerDetails")
                        .HasForeignKey("UsesDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsesDetail");
                });

            modelBuilder.Entity("Toner.Domain.Entities.UsesDetail", b =>
                {
                    b.HasOne("Toner.Domain.Entities.MachineInfo", "MachineInfo")
                        .WithMany("UsesDetails")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MachineInfo");
                });

            modelBuilder.Entity("Toner.Domain.Entities.CustomerInfo", b =>
                {
                    b.Navigation("ProjectInfos");
                });

            modelBuilder.Entity("Toner.Domain.Entities.MachineInfo", b =>
                {
                    b.Navigation("UsesDetails");
                });

            modelBuilder.Entity("Toner.Domain.Entities.ProjectInfo", b =>
                {
                    b.Navigation("MachineInfos");
                });

            modelBuilder.Entity("Toner.Domain.Entities.UsesDetail", b =>
                {
                    b.Navigation("TonerDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
