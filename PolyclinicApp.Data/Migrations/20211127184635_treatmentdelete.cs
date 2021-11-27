using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PolyclinicApp.Data.Migrations
{
    public partial class treatmentdelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MethodOfTreatment",
                table: "MedicineCards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MethodOfTreatment",
                table: "MedicineCards",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
