using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PagePass.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_CLIENTES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CliBI = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false),
                    CliNome = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    CliEndereco = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    CliCidade = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    CliBairro = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    CliNumero = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    CliTelefoneCelular = table.Column<string>(type: "VARCHAR(17)", maxLength: 17, nullable: false),
                    CliTelefoneFixo = table.Column<string>(type: "VARCHAR(17)", maxLength: 17, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_CLIENTES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_LIVROS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LivroNome = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    LivroAutor = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    LivroEditora = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    LivroAnoPublicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LivroEdicao = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_LIVROS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_EMPRESTIMOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdLivro = table.Column<int>(type: "int", nullable: false),
                    DataEmprestimo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Entrega = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_EMPRESTIMOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_EMPRESTIMOS_TBL_CLIENTES_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "TBL_CLIENTES",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBL_EMPRESTIMOS_TBL_LIVROS_IdLivro",
                        column: x => x.IdLivro,
                        principalTable: "TBL_LIVROS",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "TBL_CLIENTES",
                columns: new[] { "Id", "CliBI", "CliBairro", "CliCidade", "CliEndereco", "CliNome", "CliNumero", "CliTelefoneCelular", "CliTelefoneFixo" },
                values: new object[,]
                {
                    { 1, "007623437LD032", "Benfica", "Luanda", "Benfica Casa N 01", "Pedro Narciso", "12", "+244 914 765 765", "+244 986 322 000" },
                    { 2, "007623437LD032", "Zango", "Luanda", "Zango Casa N 01", "Maria Sousa", "10", "+244 934 654 765", "+244 986 111 123" },
                    { 3, "007623437ZE032", "Soyo", "Soyo", "Soyo Casa N 01", "Luisa Bernada", "10", "+244 934 000 000", "+244 924 123 987" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_EMPRESTIMOS_IdCliente",
                table: "TBL_EMPRESTIMOS",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_EMPRESTIMOS_IdLivro",
                table: "TBL_EMPRESTIMOS",
                column: "IdLivro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_EMPRESTIMOS");

            migrationBuilder.DropTable(
                name: "TBL_CLIENTES");

            migrationBuilder.DropTable(
                name: "TBL_LIVROS");
        }
    }
}
