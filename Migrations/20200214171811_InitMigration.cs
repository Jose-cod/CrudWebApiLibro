using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudLibrosApi.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LibroItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(nullable: false),
                    Autor = table.Column<string>(nullable: true),
                    Año = table.Column<int>(nullable: false),
                    Editorial = table.Column<string>(nullable: true),
                    Isbn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibroItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibroItems");
        }
    }
}
