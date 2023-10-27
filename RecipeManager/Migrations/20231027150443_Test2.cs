using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeManager.Migrations
{
    /// <inheritdoc />
    public partial class Test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoockingSteps",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "Ingtidients",
                table: "Recipes",
                newName: "Ingridients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ingridients",
                table: "Recipes",
                newName: "Ingtidients");

            migrationBuilder.AddColumn<string>(
                name: "CoockingSteps",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
