using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission6.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    categoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    categoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.categoryID);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    movieTitle = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    directorName = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    lentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true),
                    categoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Responses_Categories_categoryID",
                        column: x => x.categoryID,
                        principalTable: "Categories",
                        principalColumn: "categoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryID", "categoryName" },
                values: new object[] { 1, "Romance" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryID", "categoryName" },
                values: new object[] { 2, "Comedy" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryID", "categoryName" },
                values: new object[] { 3, "Romantic Comedy" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryID", "categoryName" },
                values: new object[] { 4, "Drama" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryID", "categoryName" },
                values: new object[] { 5, "Action/Adventure" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryID", "categoryName" },
                values: new object[] { 6, "Horror" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryID", "categoryName" },
                values: new object[] { 7, "Science Fiction" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryID", "categoryName" },
                values: new object[] { 8, "Documentary" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryID", "categoryName" },
                values: new object[] { 9, "Fantasy" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryID", "categoryName" },
                values: new object[] { 10, "Historical Fiction" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryID", "categoryName" },
                values: new object[] { 11, "Musical" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryID", "categoryName" },
                values: new object[] { 12, "Murder Mystery" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "MovieId", "Edited", "Notes", "Rating", "Year", "categoryID", "directorName", "lentTo", "movieTitle" },
                values: new object[] { 1, true, null, "PG-13", 2003, 3, "Donald Petrie", "", "How To Lose A Guy In Ten Days" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "MovieId", "Edited", "Notes", "Rating", "Year", "categoryID", "directorName", "lentTo", "movieTitle" },
                values: new object[] { 3, true, null, "PG", 1946, 4, "Frank Capra", "", "It's A Wonderful Life" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "MovieId", "Edited", "Notes", "Rating", "Year", "categoryID", "directorName", "lentTo", "movieTitle" },
                values: new object[] { 2, true, null, "PG", 2017, 5, "Chris McKay", "", "The Lego Batman Movie" });

            migrationBuilder.CreateIndex(
                name: "IX_Responses_categoryID",
                table: "Responses",
                column: "categoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
