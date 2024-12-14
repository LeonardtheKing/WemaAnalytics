using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WemaAnalytics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_SOLEntities_SOLId",
                table: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_Branches_SOLId",
                table: "Branches");

            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                table: "SOLEntities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SOLEntities_BranchId",
                table: "SOLEntities",
                column: "BranchId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SOLEntities_Branches_BranchId",
                table: "SOLEntities",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SOLEntities_Branches_BranchId",
                table: "SOLEntities");

            migrationBuilder.DropIndex(
                name: "IX_SOLEntities_BranchId",
                table: "SOLEntities");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "SOLEntities");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_SOLId",
                table: "Branches",
                column: "SOLId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_SOLEntities_SOLId",
                table: "Branches",
                column: "SOLId",
                principalTable: "SOLEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
