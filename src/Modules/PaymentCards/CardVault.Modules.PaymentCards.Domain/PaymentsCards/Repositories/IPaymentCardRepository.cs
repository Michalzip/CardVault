using CardVault.Modules.PaymentCards.Domain.PaymentsCards.Entities;

namespace CardVault.Modules.PaymentCards.Domain.PaymentsCards.Repositories;

public interface IPaymentCardRepository
{
    Task DeleteAsync(PaymentCard paymentCard, CancellationToken cancellationToken);
    void Insert(PaymentCard paymentCard, CancellationToken cancellationToken);
    void Update(PaymentCard paymentCard, CancellationToken cancellationToken);
    Task<PaymentCard?> GetAsync(Guid id, CancellationToken cancellationToken);
}
