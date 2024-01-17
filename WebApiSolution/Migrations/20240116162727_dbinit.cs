using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiSolution.Migrations
{
    /// <inheritdoc />
    public partial class dbinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wrong1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wrong2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wrong3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionItems");
        }
    }
}
