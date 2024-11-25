using CardVault.Modules.PaymentCards.Domain.PaymentsCards.ValueObjects.AccountNumber;
using CardVault.Modules.PaymentCards.Domain.PaymentsCards.ValueObjects.Pin;
using CardVault.Modules.PaymentCards.Domain.PaymentsCards.ValueObjects.SerialNumber;
using CardVault.Shared.Abstraction.Kernel;
using CardVault.Shared.Infrastructure.Utils;

namespace CardVault.Modules.PaymentCards.Domain.PaymentsCards.Entities;

public class PaymentCard : Entity
{
    public Guid Id { get; set; }
    public string AccountNumber { get; set; } 
    public string Pin { get; set; } 
    public string SerialNumber { get; set; } 
    public string UniqueKey { get; set; }
    
    public PaymentCard(){}
    public PaymentCard(AccountNumber accountNumber, Pin pin, SerialNumber serialNumber)
    {
        Id = Guid.NewGuid(); 
        AccountNumber = TokenizationService.Tokenize(accountNumber.Value);
        Pin = pin;
        SerialNumber = TokenizationService.Tokenize(serialNumber.Value);
        UniqueKey = DefaultUniqueKeyGenerator.GenerateUniqueKey();
    }
    
    public static PaymentCard Create(
        AccountNumber accountNumber,
        Pin pin,
        SerialNumber serialNumber
    ) =>
        new PaymentCard(accountNumber, pin, serialNumber);
}
