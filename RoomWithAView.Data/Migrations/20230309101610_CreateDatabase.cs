using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RoomWithAView.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Facilities = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPayment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "Category", "Description", "Facilities", "Number", "Price" },
                values: new object[,]
                {
                    { new Guid("03255768-996d-4dde-9dd4-567b70d08b53"), 5, "Suite", "Beautiful relaxing place for your tired feet", "Wi-Fi, TV, Air conditioner, Mini playground", 100, 500 },
                    { new Guid("1d1079a7-fa2d-4b9c-baac-843ada9e6df5"), 2, "Double", "Let yourself be spoiled by the comfort", "Wi-Fi, TV, Air conditioner, Bath tub", 200, 400 },
                    { new Guid("4246f3a8-afa9-492c-8048-b17c244b8c12"), 4, "Deluxe", "Enter the oasis of a calm and peaceful stay", "Wi-Fi, TV, Air conditioner, Bath tub,Mini bar, Daily snacks, Ocean view", 201, 600 },
                    { new Guid("bf55a8e3-6b4a-4c57-942d-ea3e904043e0"), 2, "Double", "Let yourself be spoiled by the comfort", "Wi-Fi, TV, Air conditioner, Bath tub", 102, 400 },
                    { new Guid("c0a4c4a4-d7c2-43d3-b024-05fa6e32e0d9"), 1, "Single", "A perfect recharging space", "Wi-Fi, TV, Air conditioner, Mini bar", 101, 200 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CheckIn", "CheckOut", "RoomId", "TotalPayment" },
                values: new object[,]
                {
                    { new Guid("33e38cea-1c86-4cce-999e-5316b6b4b5b4"), new DateTime(2023, 3, 6, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bf55a8e3-6b4a-4c57-942d-ea3e904043e0"), 1600 },
                    { new Guid("732b6742-f003-4148-a742-db5c4b90e086"), new DateTime(2023, 3, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 12, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4246f3a8-afa9-492c-8048-b17c244b8c12"), 1200 },
                    { new Guid("9792f414-7cd9-42dd-9677-8f5b17de9b8d"), new DateTime(2023, 3, 6, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 13, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("03255768-996d-4dde-9dd4-567b70d08b53"), 3500 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
