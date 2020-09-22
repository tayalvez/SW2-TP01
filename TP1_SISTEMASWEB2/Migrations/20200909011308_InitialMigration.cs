using Microsoft.EntityFrameworkCore.Migrations;

namespace TP1_SISTEMASWEB2.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    gender = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: false),
                    price = table.Column<double>(nullable: false),
                    qty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBooks",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idBook = table.Column<int>(nullable: false),
                    idAuthor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBooks", x => x.id);
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Author_idAuthor",
                        column: x => x.idAuthor,
                        principalTable: "Author",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Book_idBook",
                        column: x => x.idBook,
                        principalTable: "Book",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBooks_idAuthor",
                table: "AuthorBooks",
                column: "idAuthor");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBooks_idBook",
                table: "AuthorBooks",
                column: "idBook");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBooks");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}
