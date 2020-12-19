using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientInfoSystem.Infrastructure.Migrations
{
    public partial class ChangedInterfaceDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Interactions_ClientId",
                table: "Interactions");

            migrationBuilder.DropIndex(
                name: "IX_Interactions_EmpId",
                table: "Interactions");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_ClientId",
                table: "Interactions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_EmpId",
                table: "Interactions",
                column: "EmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Interactions_ClientId",
                table: "Interactions");

            migrationBuilder.DropIndex(
                name: "IX_Interactions_EmpId",
                table: "Interactions");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_ClientId",
                table: "Interactions",
                column: "ClientId",
                unique: true,
                filter: "[ClientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_EmpId",
                table: "Interactions",
                column: "EmpId",
                unique: true,
                filter: "[EmpId] IS NOT NULL");
        }
    }
}
