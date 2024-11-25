namespace CardVault.Shared.Infrastructure.Utils;

public static class DefaultUniqueKeyGenerator
{
    public static string GenerateUniqueKey()
    {
        return Guid.NewGuid().ToString("N");
    }
}
