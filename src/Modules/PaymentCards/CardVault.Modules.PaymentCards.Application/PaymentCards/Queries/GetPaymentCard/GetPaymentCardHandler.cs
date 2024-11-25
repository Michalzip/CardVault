
using CardVault.Modules.PaymentCards.Domain.PaymentsCards.Errors;
using CardVault.Shared.Abstraction.Mediator.Queries;
using CardVault.Shared.Abstraction.Postgres;
using CardVault.Shared.Abstraction.Response;
using CardVault.Shared.Infrastructure.Utils;
using Dapper;

namespace CardVault.Modules.PaymentCards.Application.PaymentCards.Queries.GetPaymentCard;

internal sealed class GetPaymentCardHandler(IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetPaymentCardQuery, GetPaymentCardResponse>
{
    public async Task<Result<GetPaymentCardResponse>> Handle(GetPaymentCardQuery request, CancellationToken cancellationToken)
    {
        var tokenizedAccountNumber = TokenizeIfNotNull(request.AccountNumber);
        var tokenizedSerialNumber = TokenizeIfNotNull(request.SerialNumber);

        await using var connection = await dbConnectionFactory.OpenConnectionAsync();

        string  sql = $"""
                        SELECT 
                            "Id" AS {nameof(GetPaymentCardResponse.Id)},
                            "AccountNumber" AS {nameof(GetPaymentCardResponse.AccountNumber)},
                            "Pin" AS {nameof(GetPaymentCardResponse.Pin)},
                            "SerialNumber" AS {nameof(GetPaymentCardResponse.SerialNumber)},
                            "UniqueKey" AS {nameof(GetPaymentCardResponse.UniqueKey)}
                        FROM "payment_cards"."PaymentCards"
                        WHERE "AccountNumber" =  @AccountNumber
                        OR "SerialNumber" = @SerialNumber
                        OR "UniqueKey" = @UniqueKey
                        
                       """;;

        var paymentCard = await connection.QueryFirstOrDefaultAsync<GetPaymentCardResponse>(sql, new
        {
            AccountNumber = tokenizedAccountNumber,
            SerialNumber = tokenizedSerialNumber,
            UniqueKey = request.UniqueKey
        });

        
        if (paymentCard == null)
        {
            return Result.Failure<GetPaymentCardResponse>(PaymentCardsErrors.NotFound());
        }
       
        var detokenizedAccountNumber = TokenizationService.Detokenize<string>(paymentCard.AccountNumber);
        var detokenizedSerialNumber = TokenizationService.Detokenize<string>(paymentCard.SerialNumber);

       
        var detokenizedCard = new GetPaymentCardResponse(
            paymentCard.Id,
            detokenizedAccountNumber,
            paymentCard.Pin,
            detokenizedSerialNumber,
            paymentCard.UniqueKey);

        return detokenizedCard;
    }

    private static string? TokenizeIfNotNull(string? value)
    {
        return value != null ? TokenizationService.Tokenize(value) : null;
    }
}

