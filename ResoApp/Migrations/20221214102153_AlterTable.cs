using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResoApp.Migrations
{
    /// <inheritdoc />
    public partial class AlterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbInvoices_TbItems",
                table: "TbInvoices");

            //migrationBuilder.DropIndex(
            //    name: "IX_TbInvoices_itemid",
            //    table: "TbInvoices");

            migrationBuilder.DropColumn(
                name: "itemid",
                table: "TbInvoices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "itemid",
                table: "TbInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TbInvoices_itemid",
                table: "TbInvoices",
                column: "itemid");

            migrationBuilder.AddForeignKey(
                name: "FK_TbInvoices_TbItems",
                table: "TbInvoices",
                column: "itemid",
                principalTable: "TbItems",
                principalColumn: "id");
        }
    }
}
