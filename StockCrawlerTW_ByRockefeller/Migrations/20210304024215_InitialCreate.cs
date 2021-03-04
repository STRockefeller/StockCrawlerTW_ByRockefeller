using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockCrawlerTW_ByRockefeller.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "stocks",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    codeName = table.Column<string>(type: "TEXT", nullable: true),
                    stockId = table.Column<string>(type: "TEXT", nullable: true),
                    tradingVolume = table.Column<string>(type: "TEXT", nullable: true),
                    tradingMoney = table.Column<string>(type: "TEXT", nullable: true),
                    openingPrice = table.Column<string>(type: "TEXT", nullable: true),
                    closingPrice = table.Column<string>(type: "TEXT", nullable: true),
                    maxPrice = table.Column<string>(type: "TEXT", nullable: true),
                    minPrice = table.Column<string>(type: "TEXT", nullable: true),
                    spread = table.Column<string>(type: "TEXT", nullable: true),
                    tradingTurnover = table.Column<string>(type: "TEXT", nullable: true),
                    PERatio = table.Column<string>(type: "TEXT", nullable: true),
                    marketValue = table.Column<string>(type: "TEXT", nullable: true),
                    tradingDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stocks", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stocks");
        }
    }
}
