using CardVault.Shared.Abstraction.Mediator.Queries;

namespace CardVault.Modules.PaymentCards.Application.PaymentCards.Queries.GetPaymentCard;

public sealed record GetPaymentCardQuery(string? AccountNumber, string? SerialNumber,string? UniqueKey):IQuery<GetPaymentCardResponse>;