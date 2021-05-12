using Microsoft.EntityFrameworkCore.Migrations;

namespace Neighborhood.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Houses_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Nombre", "Phone" },
                values: new object[,]
                {
                    { 1, "Karina", "987654321" },
                    { 2, "Marissa", "123456789" },
                    { 3, "Mayte", "987654322" },
                    { 4, "Cristina", "987654323" }
                });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "OwnerId" },
                values: new object[,]
                {
                    { 1, "Santa Fe 1", 1 },
                    { 2, "Santa Fe 2", 1 },
                    { 6, "Santa Fe 6", 1 },
                    { 8, "Santa Fe 8", 1 },
                    { 3, "Santa Fe 3", 2 },
                    { 7, "Santa Fe 7", 2 },
                    { 4, "Santa Fe 4", 3 },
                    { 5, "Santa Fe 5", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Houses_OwnerId",
                table: "Houses",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
