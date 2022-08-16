using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infera_WebApi.Migrations
{
    public partial class newrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CaseId",
                table: "Tickets",
                column: "CaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Cases_CaseId",
                table: "Tickets",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Cases_CaseId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_CaseId",
                table: "Tickets");
        }
    }
}
