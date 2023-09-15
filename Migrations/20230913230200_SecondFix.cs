using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UFINETTest.Migrations
{
    /// <inheritdoc />
    public partial class SecondFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Hotels_HotelId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Restaurants_RestaurantId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_HotelId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_RestaurantId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Countries");

            migrationBuilder.CreateTable(
                name: "CountrySites",
                columns: table => new
                {
                    CountrySitesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    RestaurantId = table.Column<int>(type: "int", nullable: true),
                    HotelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountrySites", x => x.CountrySitesId);
                    table.ForeignKey(
                        name: "FK_CountrySites_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "FK_CountrySites_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "HotelId");
                    table.ForeignKey(
                        name: "FK_CountrySites_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountrySites_CountryId",
                table: "CountrySites",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountrySites_HotelId",
                table: "CountrySites",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_CountrySites_RestaurantId",
                table: "CountrySites",
                column: "RestaurantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountrySites");

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_HotelId",
                table: "Countries",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_RestaurantId",
                table: "Countries",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Hotels_HotelId",
                table: "Countries",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Restaurants_RestaurantId",
                table: "Countries",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId");
        }
    }
}
