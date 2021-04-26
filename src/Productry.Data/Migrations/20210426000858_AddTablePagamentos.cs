using Microsoft.EntityFrameworkCore.Migrations;

namespace Productry.Data.Migrations
{
    public partial class AddTablePagamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Cartoes_CartaoId",
                table: "Compras");

            migrationBuilder.AlterColumn<int>(
                name: "CartaoId",
                table: "Compras",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartaoId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Cartoes_CartaoId",
                        column: x => x.CartaoId,
                        principalTable: "Cartoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_CartaoId",
                table: "Pagamentos",
                column: "CartaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Cartoes_CartaoId",
                table: "Compras",
                column: "CartaoId",
                principalTable: "Cartoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Cartoes_CartaoId",
                table: "Compras");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.AlterColumn<int>(
                name: "CartaoId",
                table: "Compras",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Cartoes_CartaoId",
                table: "Compras",
                column: "CartaoId",
                principalTable: "Cartoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
