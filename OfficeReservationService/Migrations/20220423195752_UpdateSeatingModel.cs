using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfficeReservationService.Migrations
{
    public partial class UpdateSeatingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanySeatingId",
                table: "Seating",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanySeatingId",
                table: "Seating");
        }
    }
}
