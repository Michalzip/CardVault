using CardVault.Modules.PaymentCards.Domain.PaymentsCards.ValueObjects.AccountNumber;
using CardVault.Modules.PaymentCards.Domain.PaymentsCards.ValueObjects.Pin;
using CardVault.Modules.PaymentCards.Domain.PaymentsCards.ValueObjects.SerialNumber;
using CardVault.Shared.Abstraction.Mediator.Commands;

namespace CardVault.Modules.PaymentCards.Application.PaymentCards.Commands.AddPaymentCard;

public record class AddPaymentCardCommand( AccountNumber AccountNumber,
    Pin Pin,
    SerialNumber SerialNumber) : ICommand<String>;
