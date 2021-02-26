using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NovaWeb.API.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "telefone",
                columns: table => new
                {
                    id_telefone = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_contato = table.Column<int>(type: "integer", nullable: false),
                    contato = table.Column<string>(type: "text", nullable: true),
                    contatoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_telefone", x => x.id_telefone);
                });

            migrationBuilder.CreateTable(
                name: "contato",
                columns: table => new
                {
                    id_contato = table.Column<int>(type: "integer", nullable: false),
                    email = table.Column<string>(type: "text", nullable: true),
                    first_name = table.Column<string>(type: "text", nullable: true),
                    last_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contato", x => x.id_contato);
                    table.ForeignKey(
                        name: "FK_contato_telefone_id_contato",
                        column: x => x.id_contato,
                        principalTable: "telefone",
                        principalColumn: "id_telefone",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_telefone_contatoId",
                table: "telefone",
                column: "contatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_telefone_contato_contatoId",
                table: "telefone",
                column: "contatoId",
                principalTable: "contato",
                principalColumn: "id_contato",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contato_telefone_id_contato",
                table: "contato");

            migrationBuilder.DropTable(
                name: "telefone");

            migrationBuilder.DropTable(
                name: "contato");
        }
    }
}
