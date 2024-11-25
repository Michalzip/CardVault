

using CardVault.Shared.Abstraction.Response;

namespace CardVault.Modules.PaymentCards.Domain.PaymentsCards.Errors;

public static class PaymentCardsErrors
{
    public static Error NotFound(Guid paymentCardId) =>
        Error.NotFound("PaymentCard.NotFound", $"The paymentCard with the identifier {paymentCardId} was not found");
    
    public static Error NotFound() =>
        Error.NotFound("PaymentCard.NotFound", $"The paymentCard  was not found");
    
    public static Error EmptyListOfPaymentCards() =>
        Error.NotFound("PaymentCards.NotFound", $"The collection of  payment cards not found");
}
