using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TonerManagement.Migrations
{
    public partial class AddtableUsesDetailandTonerDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TonerDetails",
                columns: table => new
                {
                    TonerDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_TonerDetails", x => x.TonerDetailId);
                });

            migrationBuilder.CreateTable(
                name: "UsesDetails",
                columns: table => new
                {
                    UsesDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrevCount = table.Column<int>(type: "int", nullable: false),
                    CurCount = table.Column<int>(type: "int", nullable: false),
                    TotalCount = table.Column<int>(type: "int", nullable: false),
                    TonerPercentage = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRowDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsesDetails", x => x.UsesDetailId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TonerDetails");

            migrationBuilder.DropTable(
                name: "UsesDetails");
        }
    }
}
