using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConfigAgent.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCredentialsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoinApiType",
                table: "Credentials",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoinApiType",
                table: "Credentials");
        }
    }
}
