using Microsoft.EntityFrameworkCore.Migrations;

namespace DinoTracker.Migrations
{
    public partial class AddPaleontologistName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Paleontologists",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Paleontologists");
        }
    }
}
