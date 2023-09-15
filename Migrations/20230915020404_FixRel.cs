using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UFINETTest.Migrations
{
    /// <inheritdoc />
    public partial class FixRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Countries_CountryId",
                table: "Restaurants");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Restaurants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Countries_CountryId",
                table: "Restaurants",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Countries_CountryId",
                table: "Restaurants");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Countries_CountryId",
                table: "Restaurants",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
