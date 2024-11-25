using CardVault.Modules.PaymentCards.Domain.PaymentsCards.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardVault.Modules.PaymentCards.Infrastructure.PaymentCards.Configurations;

internal  class PaymentCardsWriteConfiguration:IEntityTypeConfiguration<PaymentCard>
{
    public void Configure(EntityTypeBuilder<PaymentCard> builder)
    {
        builder.Property(q => q.Id).ValueGeneratedNever()
            .IsRequired();
        
        builder.HasIndex(x => x.AccountNumber).IsUnique();
        
        builder.HasIndex(x => x.SerialNumber).IsUnique();
        
        builder.HasIndex(x => x.UniqueKey).IsUnique();
        
        builder.ToTable("PaymentCards");
     
    }
}
