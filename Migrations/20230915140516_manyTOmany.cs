using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UFINETTest.Migrations
{
    /// <inheritdoc />
    public partial class manyTOmany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountrySites_Countries_CountryId",
                table: "CountrySites");

            migrationBuilder.DropForeignKey(
                name: "FK_CountrySites_Hotels_HotelId",
                table: "CountrySites");

            migrationBuilder.DropForeignKey(
                name: "FK_CountrySites_Restaurants_RestaurantId",
                table: "CountrySites");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Countries_CountryId",
                table: "Hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Countries_CountryId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_CountryId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_CountryId",
                table: "Hotels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountrySites",
                table: "CountrySites");

            migrationBuilder.DropIndex(
                name: "IX_CountrySites_CountryId",
                table: "CountrySites");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "CountrySitesId",
                table: "CountrySites");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "CountrySites",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HotelId",
                table: "CountrySites",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "CountrySites",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountrySites",
                table: "CountrySites",
                columns: new[] { "CountryId", "RestaurantId", "HotelId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CountrySites_Countries_CountryId",
                table: "CountrySites",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountrySites_Hotels_HotelId",
                table: "CountrySites",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "HotelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountrySites_Restaurants_RestaurantId",
                table: "CountrySites",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountrySites_Countries_CountryId",
                table: "CountrySites");

            migrationBuilder.DropForeignKey(
                name: "FK_CountrySites_Hotels_HotelId",
                table: "CountrySites");

            migrationBuilder.DropForeignKey(
                name: "FK_CountrySites_Restaurants_RestaurantId",
                table: "CountrySites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountrySites",
                table: "CountrySites");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Restaurants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Hotels",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HotelId",
                table: "CountrySites",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "CountrySites",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "CountrySites",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CountrySitesId",
                table: "CountrySites",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountrySites",
                table: "CountrySites",
                column: "CountrySitesId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CountryId",
                table: "Restaurants",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CountryId",
                table: "Hotels",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountrySites_CountryId",
                table: "CountrySites",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CountrySites_Countries_CountryId",
                table: "CountrySites",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CountrySites_Hotels_HotelId",
                table: "CountrySites",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CountrySites_Restaurants_RestaurantId",
                table: "CountrySites",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Countries_CountryId",
                table: "Hotels",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Countries_CountryId",
                table: "Restaurants",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId");
        }
    }
}
