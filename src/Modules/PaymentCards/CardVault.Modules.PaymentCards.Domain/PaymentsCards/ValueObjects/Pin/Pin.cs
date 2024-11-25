using System.Security.Cryptography;
using System.Text;
using CardVault.Modules.PaymentCards.Domain.PaymentsCards.ValueObjects.Pin.Exceptions;
using CardVault.Shared.Abstraction.Kernel;

namespace CardVault.Modules.PaymentCards.Domain.PaymentsCards.ValueObjects.Pin;

public class Pin:ValueObject
{
    public string Value { get; }
    private const int ExpectedLength = 4;

    public Pin(string rawPin)
    {
        if (string.IsNullOrWhiteSpace(rawPin) || rawPin.Length != ExpectedLength || !int.TryParse(rawPin, out _))
        {
            throw new InvalidPinException(rawPin);
        }

        Value = HashPin(rawPin);
    }
    
 
    private static string HashPin(string pin)
    {
        using var hmac = new HMACSHA256(GenerateSalt());
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pin));
        return Convert.ToBase64String(hash);
    }
    
    private static byte[] GenerateSalt()
    {
        var salt = new byte[16];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(salt);
        return salt;
    }

    public static implicit operator Pin(string value) => value is null ? null : new Pin(value);
    public static implicit operator string(Pin value) => value?.Value;
}