using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WemaAnalytics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class jj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StaffId",
                table: "WemaAnalyticUsers",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StaffId",
                table: "WemaAnalyticUsers",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9);
        }
    }
}
