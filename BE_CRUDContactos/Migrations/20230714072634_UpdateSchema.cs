using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_CRUDContactos.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favorito",
                table: "Contactos");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Contactos",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "Contactos",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "CelularNumber",
                table: "Contactos",
                newName: "Tel");

            migrationBuilder.CreateTable(
                name: "FavouriteContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouriteContacts_Contactos_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contactos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteContacts_ContactId",
                table: "FavouriteContacts",
                column: "ContactId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteContacts");

            migrationBuilder.RenameColumn(
                name: "Tel",
                table: "Contactos",
                newName: "CelularNumber");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Contactos",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Contactos",
                newName: "FechaCreacion");

            migrationBuilder.AddColumn<bool>(
                name: "Favorito",
                table: "Contactos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
