using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FluxoCaixa.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BalancoDia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    ValorCredito = table.Column<double>(nullable: false),
                    ValorDebito = table.Column<double>(nullable: false),
                    Saldo = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalancoDia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoLancamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoLancamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LancamentoFinanceiro",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataHoraLancamento = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<double>(nullable: false),
                    TipoLancamentoId = table.Column<int>(nullable: true),
                    Consolidado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancamentoFinanceiro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LancamentoFinanceiro_TipoLancamento_TipoLancamentoId",
                        column: x => x.TipoLancamentoId,
                        principalTable: "TipoLancamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoFinanceiro_TipoLancamentoId",
                table: "LancamentoFinanceiro",
                column: "TipoLancamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BalancoDia");

            migrationBuilder.DropTable(
                name: "LancamentoFinanceiro");

            migrationBuilder.DropTable(
                name: "TipoLancamento");
        }
    }
}
