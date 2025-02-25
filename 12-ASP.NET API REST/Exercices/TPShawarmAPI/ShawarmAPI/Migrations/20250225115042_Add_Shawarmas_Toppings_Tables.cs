using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShawarmAPI.Migrations
{
    /// <inheritdoc />
    public partial class Add_Shawarmas_Toppings_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.CreateTable(
                name: "shawarmas",
                columns: table => new
                {
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shawarmas", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "toppings",
                columns: table => new
                {
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_toppings", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "shawarmas_toppings",
                columns: table => new
                {
                    ShawarmasName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ToppingsName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shawarmas_toppings", x => new { x.ShawarmasName, x.ToppingsName });
                    table.ForeignKey(
                        name: "FK_shawarmas_toppings_shawarmas_ShawarmasName",
                        column: x => x.ShawarmasName,
                        principalTable: "shawarmas",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_shawarmas_toppings_toppings_ToppingsName",
                        column: x => x.ToppingsName,
                        principalTable: "toppings",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_shawarmas_toppings_ToppingsName",
                table: "shawarmas_toppings",
                column: "ToppingsName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shawarmas_toppings");

            migrationBuilder.DropTable(
                name: "shawarmas");

            migrationBuilder.DropTable(
                name: "toppings");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "Id");
        }
    }
}
