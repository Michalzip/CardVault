using CardVault.Modules.PaymentCards.Domain.PaymentsCards.ValueObjects.AccountNumber.Exceptions;
using CardVault.Shared.Abstraction.Kernel;

namespace CardVault.Modules.PaymentCards.Domain.PaymentsCards.ValueObjects.AccountNumber;

public class AccountNumber:ValueObject
{
    public string Value { get; }
    private const int ExpectedLength = 26;

    public AccountNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length != ExpectedLength)
        {
            throw new InvalidAccountNumberException(value);
        }

        Value = value;
    }

    public static implicit operator AccountNumber(string value) => value is null ? null : new AccountNumber(value);
    public static implicit operator string(AccountNumber value) => value?.Value;
}
