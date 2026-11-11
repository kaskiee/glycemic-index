using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GlycemicIndex.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDishAndMealEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    PortionCount = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                    table.CheckConstraint("CK_Dishes_PortionCount_Positive", "\"PortionCount\" > 0");
                });

            migrationBuilder.CreateTable(
                name: "FoodProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    GlycemicIndex = table.Column<int>(type: "integer", nullable: false),
                    CaloriesPer100g = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: false),
                    ProteinPer100g = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    CarbsPer100g = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    FatPer100g = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    FiberPer100g = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodProducts", x => x.Id);
                    table.CheckConstraint("CK_FoodProducts_GlycemicIndex_Range", "\"GlycemicIndex\" BETWEEN 0 AND 100");
                    table.CheckConstraint("CK_FoodProducts_Nutrition_NonNegative", "\"CaloriesPer100g\" >= 0 AND \"ProteinPer100g\" >= 0 AND \"CarbsPer100g\" >= 0 AND \"FatPer100g\" >= 0 AND \"FiberPer100g\" >= 0");
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    MealCategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meals_MealCategories_MealCategoryId",
                        column: x => x.MealCategoryId,
                        principalTable: "MealCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DishItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DishId = table.Column<int>(type: "integer", nullable: false),
                    FoodProductId = table.Column<int>(type: "integer", nullable: false),
                    QuantityGrams = table.Column<decimal>(type: "numeric(7,2)", precision: 7, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishItems", x => x.Id);
                    table.CheckConstraint("CK_DishItems_QuantityGrams_Positive", "\"QuantityGrams\" > 0");
                    table.ForeignKey(
                        name: "FK_DishItems_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishItems_FoodProducts_FoodProductId",
                        column: x => x.FoodProductId,
                        principalTable: "FoodProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MealEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MealId = table.Column<int>(type: "integer", nullable: false),
                    FoodProductId = table.Column<int>(type: "integer", nullable: true),
                    QuantityGrams = table.Column<decimal>(type: "numeric(7,2)", precision: 7, scale: 2, nullable: false),
                    DishId = table.Column<int>(type: "integer", nullable: true),
                    Portions = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    Calories = table.Column<decimal>(type: "numeric(7,1)", precision: 7, scale: 1, nullable: false),
                    Protein = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: false),
                    Carbs = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: false),
                    Fat = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: false),
                    Fiber = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: false),
                    GlycemicIndex = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealEntries", x => x.Id);
                    table.CheckConstraint("CK_MealEntries_DishPortions_Required", "\"DishId\" IS NULL OR (\"Portions\" IS NOT NULL AND \"Portions\" > 0)");
                    table.CheckConstraint("CK_MealEntries_Nutrition_NonNegative", "\"Calories\" >= 0 AND \"Protein\" >= 0 AND \"Carbs\" >= 0 AND \"Fat\" >= 0 AND \"Fiber\" >= 0");
                    table.CheckConstraint("CK_MealEntries_Position_ProductXorDish", "(\"FoodProductId\" IS NOT NULL AND \"DishId\" IS NULL) OR (\"FoodProductId\" IS NULL AND \"DishId\" IS NOT NULL)");
                    table.CheckConstraint("CK_MealEntries_QuantityGrams_Positive", "\"QuantityGrams\" > 0");
                    table.ForeignKey(
                        name: "FK_MealEntries_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MealEntries_FoodProducts_FoodProductId",
                        column: x => x.FoodProductId,
                        principalTable: "FoodProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MealEntries_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_Name",
                table: "Dishes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_DishItems_DishId",
                table: "DishItems",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_DishItems_FoodProductId",
                table: "DishItems",
                column: "FoodProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodProducts_Name",
                table: "FoodProducts",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_MealEntries_DishId",
                table: "MealEntries",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_MealEntries_FoodProductId",
                table: "MealEntries",
                column: "FoodProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MealEntries_MealId",
                table: "MealEntries",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_Date",
                table: "Meals",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MealCategoryId",
                table: "Meals",
                column: "MealCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishItems");

            migrationBuilder.DropTable(
                name: "MealEntries");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "FoodProducts");

            migrationBuilder.DropTable(
                name: "Meals");
        }
    }
}
