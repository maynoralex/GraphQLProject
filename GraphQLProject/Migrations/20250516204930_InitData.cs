using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GraphQLProject.Migrations
{
    /// <inheritdoc />
    public partial class InitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PartySize = table.Column<int>(type: "integer", nullable: false),
                    SpecialRequest = table.Column<string>(type: "text", nullable: true),
                    ReservationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "https://example.com/categories/appetizers.jpg", "Appetizers" },
                    { 2, "https://example.com/categories/main-course.jpg", "Main Course" },
                    { 3, "https://example.com/categories/desserts.jpg", "Desserts" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Spicy chicken wings served with blue cheese dip.", "https://example.com/menus/chicken-wings.jpg", "Chicken Wings", 9.9900000000000002 },
                    { 2, 2, "Grilled steak with mashed potatoes and vegetables.", "https://example.com/menus/steak.jpg", "Steak", 24.5 },
                    { 3, 3, "Decadent chocolate cake with a scoop of vanilla ice cream.", "https://example.com/menus/chocolate-cake.jpg", "Chocolate Cake", 6.9500000000000002 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerName", "Email", "PartySize", "PhoneNumber", "ReservationDate", "SpecialRequest" },
                values: new object[,]
                {
                    { 1, "John Doe", "johndoe@example.com", 2, "555-123-4567", new DateTime(2025, 5, 23, 22, 0, 0, 0, DateTimeKind.Utc), "No nuts in the dishes, please." },
                    { 2, "Jane Smith", "janesmith@example.com", 4, "555-987-6543", new DateTime(2025, 5, 26, 22, 0, 0, 0, DateTimeKind.Utc), "Gluten-free options required." },
                    { 3, "Michael Johnson", "michaeljohnson@example.com", 6, "555-789-0123", new DateTime(2025, 5, 30, 22, 0, 0, 0, DateTimeKind.Utc), "Celebrating a birthday." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
