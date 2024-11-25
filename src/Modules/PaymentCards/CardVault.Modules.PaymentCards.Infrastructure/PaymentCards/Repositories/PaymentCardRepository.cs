using CardVault.Modules.PaymentCards.Domain.PaymentsCards.Entities;
using CardVault.Modules.PaymentCards.Domain.PaymentsCards.Repositories;
using CardVault.Modules.PaymentCards.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CardVault.Modules.PaymentCards.Infrastructure.PaymentCards.Repositories;

internal sealed class PaymentCardRepository(PaymentWriteCardsContext dbContext): 
    IPaymentCardRepository
{
    public async Task DeleteAsync(PaymentCard paymentCard, CancellationToken cancellationToken)
    {
        dbContext.PaymentCards.Remove(paymentCard);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Insert(PaymentCard paymentCard, CancellationToken cancellationToken)
    {
         dbContext.PaymentCards.AddAsync(paymentCard, cancellationToken);
       
    }

    public  void Update(PaymentCard paymentCard, CancellationToken cancellationToken)
    {
        dbContext.PaymentCards.Update(paymentCard);
    }

    public async Task<PaymentCard?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.PaymentCards.SingleOrDefaultAsync(i => i.Id == id,cancellationToken);

    }
}
