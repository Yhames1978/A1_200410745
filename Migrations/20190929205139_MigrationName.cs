using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace A1_200410745.Migrations
{
    public partial class MigrationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    AnimalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.AnimalId);
                });

            migrationBuilder.CreateTable(
                name: "PetFood",
                columns: table => new
                {
                    PetFoodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    NutritionalInformation = table.Column<string>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    Brand = table.Column<string>(nullable: false),
                    AnimalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetFood", x => x.PetFoodId);
                    table.ForeignKey(
                        name: "FK_PetFood_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "AnimalId", "Description", "Name" },
                values: new object[] { 1, "Very Cute", "Cat" });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "AnimalId", "Description", "Name" },
                values: new object[] { 2, "Hairy", "Dog" });

            migrationBuilder.CreateIndex(
                name: "IX_PetFood_AnimalId",
                table: "PetFood",
                column: "AnimalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetFood");

            migrationBuilder.DropTable(
                name: "Animal");
        }
    }
}
