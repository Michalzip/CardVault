using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardVault.Modules.PaymentCards.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class change_value_key_property_as_unique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PaymentCards_UniqueKey",
                schema: "payment_cards",
                table: "PaymentCards",
                column: "UniqueKey",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PaymentCards_UniqueKey",
                schema: "payment_cards",
                table: "PaymentCards");
        }
    }
}
