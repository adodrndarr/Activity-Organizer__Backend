using Microsoft.EntityFrameworkCore.Migrations;

namespace ActivityOrganizer.Migrations
{
    public partial class ActivityWithPriorities_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "SpecialActivity");

            migrationBuilder.AddColumn<string>(
                name: "ActivityPriority",
                table: "SpecialActivity",
                maxLength: 25,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityPriority",
                table: "SpecialActivity");

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "SpecialActivity",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");
        }
    }
}
