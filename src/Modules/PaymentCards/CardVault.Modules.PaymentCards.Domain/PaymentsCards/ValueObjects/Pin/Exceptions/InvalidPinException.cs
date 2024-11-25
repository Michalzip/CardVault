using CardVault.Shared.Abstraction.Exceptions.PigenerException;

namespace CardVault.Modules.PaymentCards.Domain.PaymentsCards.ValueObjects.Pin.Exceptions;
internal class InvalidPinException(string pin) : CardVaultException($"Pin: '{pin}' is invalid. It must be exactly 4 numeric characters.")
{
    public string Pin { get; } = pin;
}
