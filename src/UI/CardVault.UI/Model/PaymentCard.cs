namespace CardVault.UI.Model
{
    public class PaymentCard
    {
        public Guid Id { get; set; }
        public string AccountNumber { get; set; }
        public string Pin { get; set; }
        public string SerialNumber { get; set; }
        public string UniqueKey { get; set; }
    }
}
