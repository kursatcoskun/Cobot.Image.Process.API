using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanParts.Detection.API.Migrations
{
    public partial class migrationV001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetectedObjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetectedObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    rosVersion = table.Column<string>(nullable: true),
                    OperatingSystemVersion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Detections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    detectedObjectId = table.Column<int>(nullable: false),
                    detectionTime = table.Column<DateTime>(nullable: false),
                    deviceId = table.Column<string>(nullable: false),
                    deviceId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detections_DetectedObjects_detectedObjectId",
                        column: x => x.detectedObjectId,
                        principalTable: "DetectedObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detections_Devices_deviceId1",
                        column: x => x.deviceId1,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detections_detectedObjectId",
                table: "Detections",
                column: "detectedObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Detections_deviceId1",
                table: "Detections",
                column: "deviceId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detections");

            migrationBuilder.DropTable(
                name: "DetectedObjects");

            migrationBuilder.DropTable(
                name: "Devices");
        }
    }
}
