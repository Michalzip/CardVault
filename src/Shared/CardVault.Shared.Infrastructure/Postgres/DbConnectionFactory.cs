using System.Data.Common;
using CardVault.Shared.Abstraction.Postgres;
using Npgsql;

namespace CardVault.Shared.Infrastructure.Postgres;

internal sealed class DbConnectionFactory(NpgsqlDataSource dataSource) : IDbConnectionFactory
{
    public async ValueTask<DbConnection> OpenConnectionAsync()
    {
        return await dataSource.OpenConnectionAsync();
    }
}
