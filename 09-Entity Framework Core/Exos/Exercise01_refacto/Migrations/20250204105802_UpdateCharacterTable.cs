using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercise01_refacto.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCharacterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HitChance",
                table: "RPGCharacters");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HitChance",
                table: "RPGCharacters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
