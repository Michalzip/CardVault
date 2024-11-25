namespace CardVault.Modules.PaymentCards.Infrastructure.PaymentCards.Configurations;

internal sealed class PaymentCardReadModel
{
    public Guid Id { get; set; }
    public string AccountNumber { get; set; } 
    public string Pin { get; set; } 
    public string SerialNumber { get; set; } 
}
