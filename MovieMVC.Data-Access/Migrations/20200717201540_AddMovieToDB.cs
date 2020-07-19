using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieMVC.Data_Access.Migrations
{
    public partial class AddMovieToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ISBN = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    ListPrice = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Price50 = table.Column<double>(nullable: false),
                    Price100 = table.Column<double>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    DeliveryTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_DeliveryTypes_DeliveryTypeId",
                        column: x => x.DeliveryTypeId,
                        principalTable: "DeliveryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CategoryId",
                table: "Movies",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DeliveryTypeId",
                table: "Movies",
                column: "DeliveryTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
