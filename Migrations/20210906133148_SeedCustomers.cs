using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieRentalsAPI.Migrations
{
    public partial class SeedCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT Customers ON");
            migrationBuilder.Sql("INSERT INTO Customers (Id, Name, Email, PhoneNumber) VALUES (1, 'Customer 1', 'customer1@gmail.com', '0950217179')");
            migrationBuilder.Sql("INSERT INTO Customers (Id, Name, Email, PhoneNumber) VALUES (2, 'Customer 2', 'customer2@gmail.com', '0990357139')");
            migrationBuilder.Sql("INSERT INTO Customers (Id, Name, Email, PhoneNumber) VALUES (3, 'Customer 3', 'customer3@gmail.com', '0993205117')");
            migrationBuilder.Sql("INSERT INTO Customers (Id, Name, Email, PhoneNumber) VALUES (4, 'Customer 4', 'customer4@gmail.com', '0960262110')");
            migrationBuilder.Sql("INSERT INTO Customers (Id, Name, Email, PhoneNumber) VALUES (5, 'Customer 5', 'customer5@gmail.com', '0958690189')");
            migrationBuilder.Sql("SET IDENTITY_INSERT Customers OFF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Customers WHERE Id <= 5");
        }
    }
}
