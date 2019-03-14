using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanParts.Detection.API.Migrations
{
    public partial class migrationV002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detections_DetectedObjects_detectedObjectId",
                table: "Detections");

            migrationBuilder.DropForeignKey(
                name: "FK_Detections_Devices_deviceId1",
                table: "Detections");

            migrationBuilder.DropIndex(
                name: "IX_Detections_detectedObjectId",
                table: "Detections");

            migrationBuilder.DropIndex(
                name: "IX_Detections_deviceId1",
                table: "Detections");

            migrationBuilder.DropColumn(
                name: "deviceId1",
                table: "Detections");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "deviceId1",
                table: "Detections",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Detections_detectedObjectId",
                table: "Detections",
                column: "detectedObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Detections_deviceId1",
                table: "Detections",
                column: "deviceId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Detections_DetectedObjects_detectedObjectId",
                table: "Detections",
                column: "detectedObjectId",
                principalTable: "DetectedObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Detections_Devices_deviceId1",
                table: "Detections",
                column: "deviceId1",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
