using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OxygenLab.Data.Migrations
{
    public partial class desc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Experiments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Experiments");
        }
    }
}
