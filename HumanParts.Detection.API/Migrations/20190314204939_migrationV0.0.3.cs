using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanParts.Detection.API.Migrations
{
    public partial class migrationV003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "deviceId",
                table: "Detections",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "deviceId",
                table: "Detections",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
