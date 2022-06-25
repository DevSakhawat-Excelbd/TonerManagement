using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TonerManagement.Migrations
{
    public partial class CustomerIdisForeignKeyinMachineInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerInfos",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRowDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInfos", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "TonerInfos",
                columns: table => new
                {
                    TonerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TonerModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BW = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cyan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    M = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Y = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    K = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalMachineToner = table.Column<double>(type: "float", nullable: false),
                    CurrentTonerStock = table.Column<double>(type: "float", nullable: false),
                    InHouseTotalToner = table.Column<double>(type: "float", nullable: false),
                    LastMonthTotalTonerStock = table.Column<double>(type: "float", nullable: false),
                    MonthlyDeliveryToner = table.Column<double>(type: "float", nullable: false),
                    TotalTonerStock = table.Column<double>(type: "float", nullable: false),
                    MonthlyUsedToner = table.Column<double>(type: "float", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRowDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TonerInfos", x => x.TonerId);
                });

            migrationBuilder.CreateTable(
                name: "MachineInfos",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MachineModel = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerInfoCustomerId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRowDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineInfos", x => x.MachineId);
                    table.ForeignKey(
                        name: "FK_MachineInfos_CustomerInfos_CustomerInfoCustomerId",
                        column: x => x.CustomerInfoCustomerId,
                        principalTable: "CustomerInfos",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "ProjectInfos",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerInfoCustomerId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRowDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectInfos", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_ProjectInfos_CustomerInfos_CustomerInfoCustomerId",
                        column: x => x.CustomerInfoCustomerId,
                        principalTable: "CustomerInfos",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MachineInfos_CustomerInfoCustomerId",
                table: "MachineInfos",
                column: "CustomerInfoCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectInfos_CustomerInfoCustomerId",
                table: "ProjectInfos",
                column: "CustomerInfoCustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MachineInfos");

            migrationBuilder.DropTable(
                name: "ProjectInfos");

            migrationBuilder.DropTable(
                name: "TonerInfos");

            migrationBuilder.DropTable(
                name: "CustomerInfos");
        }
    }
}
