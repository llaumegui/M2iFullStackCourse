using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_Exercises.Migrations
{
    /// <inheritdoc />
    public partial class AddLuck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HitChance",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HitChance",
                table: "Characters");
        }
    }
}
