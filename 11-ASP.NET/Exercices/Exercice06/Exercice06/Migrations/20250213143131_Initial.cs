using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercice06.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Watched = table.Column<bool>(type: "bit", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Synopsis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "Genre", "Synopsis", "Title", "Watched", "Year" },
                values: new object[] { 1, "Christopher Nolan", "Action", "Dans la ville de Gotham City, une bande de cambrioleurs déguisés en clowns dévalisent une banque servant à la mafia pour blanchir son argent sale. Chacun des cambrioleurs doit se débarrasser d'un de ses complices, jusqu’à ce qu’il n’en reste plus qu’un : le commanditaire du casse, un psychopathe fou et particulièrement dangereux : le Joker.", "The Dark Knight", false, 2008 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
