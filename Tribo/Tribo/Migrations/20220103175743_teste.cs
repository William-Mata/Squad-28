using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tribo.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    IdContato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.IdContato);
                });

            migrationBuilder.CreateTable(
                name: "Imagem",
                columns: table => new
                {
                    IdImg = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dados = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagem", x => x.IdImg);
                });

            migrationBuilder.CreateTable(
                name: "Pacote",
                columns: table => new
                {
                    IdPacote = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_Imagem = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacote", x => x.IdPacote);
                    table.ForeignKey(
                        name: "FK_Pacote_Imagem_Id_Imagem",
                        column: x => x.Id_Imagem,
                        principalTable: "Imagem",
                        principalColumn: "IdImg");
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Pacote = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Cliente_Pacote_Id_Pacote",
                        column: x => x.Id_Pacote,
                        principalTable: "Pacote",
                        principalColumn: "IdPacote");
                });

            migrationBuilder.CreateTable(
                name: "TriboParceira",
                columns: table => new
                {
                    IdTribo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeTribo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Pacote = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TriboParceira", x => x.IdTribo);
                    table.ForeignKey(
                        name: "FK_TriboParceira_Pacote_Id_Pacote",
                        column: x => x.Id_Pacote,
                        principalTable: "Pacote",
                        principalColumn: "IdPacote");
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Cliente = table.Column<int>(type: "int", nullable: true),
                    Id_Contato = table.Column<int>(type: "int", nullable: true),
                    Id_TriboParceira = table.Column<int>(type: "int", nullable: true),
                    Id_Pacote = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admin_Cliente_Id_Cliente",
                        column: x => x.Id_Cliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente");
                    table.ForeignKey(
                        name: "FK_Admin_Contato_Id_Contato",
                        column: x => x.Id_Contato,
                        principalTable: "Contato",
                        principalColumn: "IdContato");
                    table.ForeignKey(
                        name: "FK_Admin_Pacote_Id_Pacote",
                        column: x => x.Id_Pacote,
                        principalTable: "Pacote",
                        principalColumn: "IdPacote");
                    table.ForeignKey(
                        name: "FK_Admin_TriboParceira_Id_TriboParceira",
                        column: x => x.Id_TriboParceira,
                        principalTable: "TriboParceira",
                        principalColumn: "IdTribo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Id_Cliente",
                table: "Admin",
                column: "Id_Cliente",
                unique: true,
                filter: "[Id_Cliente] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Id_Contato",
                table: "Admin",
                column: "Id_Contato",
                unique: true,
                filter: "[Id_Contato] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Id_Pacote",
                table: "Admin",
                column: "Id_Pacote",
                unique: true,
                filter: "[Id_Pacote] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Id_TriboParceira",
                table: "Admin",
                column: "Id_TriboParceira",
                unique: true,
                filter: "[Id_TriboParceira] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Id_Pacote",
                table: "Cliente",
                column: "Id_Pacote",
                unique: true,
                filter: "[Id_Pacote] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pacote_Id_Imagem",
                table: "Pacote",
                column: "Id_Imagem",
                unique: true,
                filter: "[Id_Imagem] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TriboParceira_Id_Pacote",
                table: "TriboParceira",
                column: "Id_Pacote",
                unique: true,
                filter: "[Id_Pacote] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Contato");

            migrationBuilder.DropTable(
                name: "TriboParceira");

            migrationBuilder.DropTable(
                name: "Pacote");

            migrationBuilder.DropTable(
                name: "Imagem");
        }
    }
}
