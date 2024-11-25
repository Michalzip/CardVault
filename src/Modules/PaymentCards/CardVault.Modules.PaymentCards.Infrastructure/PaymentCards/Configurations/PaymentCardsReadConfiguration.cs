using CardVault.Modules.PaymentCards.Domain.PaymentsCards.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardVault.Modules.PaymentCards.Infrastructure.PaymentCards.Configurations;

internal  class PaymentCardsReadConfiguration:IEntityTypeConfiguration<PaymentCardReadModel>
{
    public void Configure(EntityTypeBuilder<PaymentCardReadModel> builder)
    {
        builder.HasKey(q => q.Id);
        builder.ToTable("PaymentCards");
     
    }
}
