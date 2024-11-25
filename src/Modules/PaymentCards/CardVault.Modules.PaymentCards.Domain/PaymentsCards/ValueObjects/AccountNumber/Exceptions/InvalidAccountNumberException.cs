using CardVault.Shared.Abstraction.Exceptions.PigenerException;

namespace CardVault.Modules.PaymentCards.Domain.PaymentsCards.ValueObjects.AccountNumber.Exceptions;

internal class InvalidAccountNumberException(string accountNumber)
    : CardVaultException($"AccountNumber: '{accountNumber}' is invalid. It must be exactly 26 numeric characters.")
{
    public string AccountNumber { get; } = accountNumber;
}
