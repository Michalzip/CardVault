using System.Data.Common;

namespace CardVault.Shared.Abstraction.Postgres;

public interface IDbConnectionFactory
{
    ValueTask<DbConnection> OpenConnectionAsync();
}
