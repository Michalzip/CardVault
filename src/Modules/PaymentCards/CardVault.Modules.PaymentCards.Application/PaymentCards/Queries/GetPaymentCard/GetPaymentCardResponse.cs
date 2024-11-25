namespace CardVault.Modules.PaymentCards.Application.PaymentCards.Queries.GetPaymentCard;

public sealed record GetPaymentCardResponse(Guid Id,string AccountNumber,string Pin,string SerialNumber,string UniqueKey);