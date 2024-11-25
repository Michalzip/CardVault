using CardVault.Modules.PaymentCards.Domain.PaymentsCards.ValueObjects.SerialNumber.Exceptions;
using CardVault.Shared.Abstraction.Kernel;

namespace CardVault.Modules.PaymentCards.Domain.PaymentsCards.ValueObjects.SerialNumber;

public class SerialNumber:ValueObject
{
    public string Value { get; }
    private const int ExpectedLength = 16;

    public SerialNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length != ExpectedLength || !ulong.TryParse(value, out _))
        {
            throw new InvalidSerialNumberException(value);
        }

        Value = value;
    }

    public static implicit operator SerialNumber(string value) => value is null ? null : new SerialNumber(value);
    public static implicit operator string(SerialNumber value) => value?.Value;
}
