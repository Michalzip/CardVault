using CardVault.Shared.Abstraction.Mediator.Commands;

namespace CardVault.Modules.PaymentCards.Application.PaymentCards.Commands.DeletePaymentCard;


public record class DeletePaymentCardCommand(Guid PaymentCardId) : ICommand;
