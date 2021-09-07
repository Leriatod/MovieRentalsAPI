using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieRentalsAPI.Migrations
{
    public partial class SeedMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT Movies ON");
            migrationBuilder.Sql("INSERT INTO Movies (Id, Name, NumberInStock, DailyRentalRate, Barcode) VALUES (1, 'Movie 1', 5, 10.50, 'Barcode 1')");
            migrationBuilder.Sql("INSERT INTO Movies (Id, Name, NumberInStock, DailyRentalRate, Barcode) VALUES (2, 'Movie 2', 10, 10.50, 'Barcode 2')");
            migrationBuilder.Sql("INSERT INTO Movies (Id, Name, NumberInStock, DailyRentalRate, Barcode) VALUES (3, 'Movie 3', 7, 7.50, 'Barcode 3')");
            migrationBuilder.Sql("INSERT INTO Movies (Id, Name, NumberInStock, DailyRentalRate, Barcode) VALUES (4, 'Movie 4', 3, 8.50, 'Barcode 4')");
            migrationBuilder.Sql("INSERT INTO Movies (Id, Name, NumberInStock, DailyRentalRate, Barcode) VALUES (5, 'Movie 5', 4, 9.50, 'Barcode 5')");
            migrationBuilder.Sql("INSERT INTO Movies (Id, Name, NumberInStock, DailyRentalRate, Barcode) VALUES (6, 'Movie 6', 2, 15.50, 'Barcode 6')");
            migrationBuilder.Sql("SET IDENTITY_INSERT Movies OFF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Movies WHERE Id <= 6");
        }
    }
}
