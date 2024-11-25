namespace CardVault.Shared.Abstraction.Exceptions.PigenerException;


public abstract class CardVaultException : Exception
{
    protected CardVaultException(string message) : base(message) { }
}