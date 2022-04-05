using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightService.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasScheduled = table.Column<bool>(type: "bit", nullable: false),
                    CaptainId = table.Column<int>(type: "int", nullable: true),
                    CoPilotId = table.Column<int>(type: "int", nullable: true),
                    SeniorCrewId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Crew1Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Crew2Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Crew3Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flight");
        }
    }
}