using System.Data.Common;
using CardVault.Modules.PaymentCards.Application.Abstractions.Data;
using CardVault.Modules.PaymentCards.Domain.PaymentsCards.Entities;
using CardVault.Modules.PaymentCards.Infrastructure.PaymentCards.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CardVault.Modules.PaymentCards.Infrastructure.Context;

internal  class PaymentWriteCardsContext(DbContextOptions<PaymentWriteCardsContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<PaymentCard> PaymentCards { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("payment_cards");
        modelBuilder.ApplyConfiguration(new PaymentCardsWriteConfiguration());
    }

    public async Task<DbTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (Database.CurrentTransaction is not null)
        {
            await Database.CurrentTransaction.DisposeAsync();
        }

        return (await Database.BeginTransactionAsync(cancellationToken)).GetDbTransaction();
    }
}
