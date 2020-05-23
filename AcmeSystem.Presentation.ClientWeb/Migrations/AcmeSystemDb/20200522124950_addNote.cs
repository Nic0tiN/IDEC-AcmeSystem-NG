using Microsoft.EntityFrameworkCore.Migrations;

namespace AcmeSystem.Presentation.ClientWeb.Migrations.AcmeSystemDb
{
    public partial class addNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NewProp",
                table: "Contacts",
                newName: "Note");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Contacts",
                newName: "NewProp");
        }
    }
}
