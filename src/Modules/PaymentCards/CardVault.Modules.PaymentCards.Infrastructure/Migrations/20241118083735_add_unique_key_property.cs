using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardVault.Modules.PaymentCards.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_unique_key_property : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "payment_cards");

            migrationBuilder.RenameTable(
                name: "PaymentCards",
                newName: "PaymentCards",
                newSchema: "payment_cards");

            migrationBuilder.AddColumn<string>(
                name: "UniqueKey",
                schema: "payment_cards",
                table: "PaymentCards",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniqueKey",
                schema: "payment_cards",
                table: "PaymentCards");

            migrationBuilder.RenameTable(
                name: "PaymentCards",
                schema: "payment_cards",
                newName: "PaymentCards");
        }
    }
}
