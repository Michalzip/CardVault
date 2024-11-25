using CardVault.Shared.Abstraction.Mediator.Commands;
using CardVault.Shared.Abstraction.Response;

namespace CardVault.Modules.PaymentCards.Application.PaymentCards.Commands.DeletePaymentCard;
using CardVault.Modules.PaymentCards.Domain.PaymentsCards.Errors;
using CardVault.Modules.PaymentCards.Domain.PaymentsCards.Repositories;


public sealed class DeletePaymentCardHandler(IPaymentCardRepository paymentCardRepository) : 
    ICommandHandler<DeletePaymentCardCommand>
{
   
    public async Task<Result> Handle(DeletePaymentCardCommand command, CancellationToken cancellationToken)
    {
        var paymentCard = await paymentCardRepository.GetAsync(command.PaymentCardId,cancellationToken);

        if (paymentCard == null) return Result.Failure(PaymentCardsErrors.NotFound(command.PaymentCardId)); 
            
        await paymentCardRepository.DeleteAsync(paymentCard,cancellationToken);
        
        return Result.Success();
    }
}
