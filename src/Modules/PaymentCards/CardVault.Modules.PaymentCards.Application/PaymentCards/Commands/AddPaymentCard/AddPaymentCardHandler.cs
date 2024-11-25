using System.Data.Common;
using CardVault.Modules.PaymentCards.Application.Abstractions.Data;
using CardVault.Modules.PaymentCards.Domain.PaymentsCards.Entities;
using CardVault.Modules.PaymentCards.Domain.PaymentsCards.Repositories;
using CardVault.Shared.Abstraction.Mediator.Commands;
using CardVault.Shared.Abstraction.Response;

namespace CardVault.Modules.PaymentCards.Application.PaymentCards.Commands.AddPaymentCard;


public sealed class AddPaymentCardHandler(IPaymentCardRepository paymentCardRepository,IUnitOfWork unitOfWork) : 
    ICommandHandler<AddPaymentCardCommand, String>
{
   
    public async Task<Result<String>> Handle(AddPaymentCardCommand command, CancellationToken cancellationToken)
    {
        
        await using DbTransaction transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);
        
        var paymentCard = PaymentCard.Create(command.AccountNumber, command.Pin, command.SerialNumber);
        
         paymentCardRepository.Insert(paymentCard,cancellationToken);

         await  unitOfWork.SaveChangesAsync(cancellationToken);
         
         await transaction.CommitAsync(cancellationToken);
         
        return paymentCard.UniqueKey;
    }
}
