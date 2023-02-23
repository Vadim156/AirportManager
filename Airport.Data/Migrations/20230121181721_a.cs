using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airport.Data.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TerminalNumber = table.Column<int>(type: "int", nullable: true),
                    TerminalId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassengersCount = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<int>(type: "int", nullable: false),
                    IsDeparture = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                });

            migrationBuilder.CreateTable(
                name: "Terminals",
                columns: table => new
                {
                    TerminalId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FlightId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TerminalNumber = table.Column<int>(type: "int", nullable: false),
                    CrossingTime = table.Column<double>(type: "float", nullable: false),
                    IsFree = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminals", x => x.TerminalId);
                    table.ForeignKey(
                        name: "FK_Terminals_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId");
                });

            migrationBuilder.CreateTable(
                name: "Loggers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TerminalId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    In = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Out = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loggers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loggers_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loggers_Terminals_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminals",
                        principalColumn: "TerminalId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_TerminalId",
                table: "Flights",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_Loggers_FlightId",
                table: "Loggers",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Loggers_TerminalId",
                table: "Loggers",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_Terminals_FlightId",
                table: "Terminals",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Terminals_TerminalId",
                table: "Flights",
                column: "TerminalId",
                principalTable: "Terminals",
                principalColumn: "TerminalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Terminals_TerminalId",
                table: "Flights");

            migrationBuilder.DropTable(
                name: "Loggers");

            migrationBuilder.DropTable(
                name: "Terminals");

            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
