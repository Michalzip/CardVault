using CardVault.Modules.PaymentCards.Domain.PaymentsCards.Entities;
using CardVault.Modules.PaymentCards.Infrastructure.PaymentCards.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CardVault.Modules.PaymentCards.Infrastructure.Context;

internal  class PaymentReadCardsContext(DbContextOptions<PaymentReadCardsContext> options) : DbContext(options)
{
    public DbSet<PaymentCard> PaymentCards { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("payment_cards");
        modelBuilder.ApplyConfiguration(new PaymentCardsReadConfiguration());
    }
}
