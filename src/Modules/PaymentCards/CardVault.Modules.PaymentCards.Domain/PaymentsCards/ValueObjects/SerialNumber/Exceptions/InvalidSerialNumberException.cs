using CardVault.Shared.Abstraction.Exceptions.PigenerException;

namespace CardVault.Modules.PaymentCards.Domain.PaymentsCards.ValueObjects.SerialNumber.Exceptions;


internal class InvalidSerialNumberException(string serialNumber) : CardVaultException($"SerialNumber: '{serialNumber}' is invalid. It must be exactly 16 numeric characters.")
{
    public string SerialNumber { get; } = serialNumber;
}