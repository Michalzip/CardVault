using Microsoft.AspNetCore.Routing;

namespace CardVault.Shared.Abstraction.Endpoints
{
    public interface IEndpoint
    {
        void MapEndpoint(IEndpointRouteBuilder app);
    }
}
