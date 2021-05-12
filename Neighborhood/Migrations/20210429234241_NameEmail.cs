using Microsoft.EntityFrameworkCore.Migrations;

namespace Neighborhood.Migrations
{
    public partial class NameEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Owners",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "OwnerId" },
                values: new object[] { 9, "Santa Fe 9", 1 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "karina@mail.com");

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "marissa@mail.com");

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 3,
                column: "Email",
                value: "mayte@mail.com");

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 4,
                column: "Email",
                value: "cristina@mail.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Owners");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Owners",
                newName: "Nombre");
        }
    }
}
