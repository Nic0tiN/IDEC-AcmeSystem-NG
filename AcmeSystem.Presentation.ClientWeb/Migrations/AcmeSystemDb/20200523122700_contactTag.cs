using Microsoft.EntityFrameworkCore.Migrations;

namespace AcmeSystem.Presentation.ClientWeb.Migrations.AcmeSystemDb
{
    public partial class contactTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Contacts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Contacts");
        }
    }
}
