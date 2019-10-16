using Microsoft.EntityFrameworkCore.Migrations;

namespace A1_200410745.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PetFood",
                columns: new[] { "PetFoodId", "AnimalId", "Brand", "Description", "Name", "NutritionalInformation", "Price", "Weight" },
                values: new object[] { 1, 2, "Prime", "Yummy Dog Food", "Doggy Best", "High in vitamins", 13.00m, 4m });

            migrationBuilder.InsertData(
                table: "PetFood",
                columns: new[] { "PetFoodId", "AnimalId", "Brand", "Description", "Name", "NutritionalInformation", "Price", "Weight" },
                values: new object[] { 2, 1, "One", "High End Cat Food", "One Cat Food", "Made only from Chiken", 14.00m, 20m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PetFood",
                keyColumn: "PetFoodId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PetFood",
                keyColumn: "PetFoodId",
                keyValue: 2);
        }
    }
}
