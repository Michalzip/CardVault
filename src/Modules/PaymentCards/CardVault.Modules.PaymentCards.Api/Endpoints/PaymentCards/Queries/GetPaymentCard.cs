using CardVault.Modules.PaymentCards.Application.PaymentCards.Queries.GetPaymentCard;
using CardVault.Shared.Abstraction;
using CardVault.Shared.Abstraction.Response;
using CardVault.Shared.Abstraction.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace CardVault.Modules.PaymentCards.Api.Endpoints.PaymentCards.Queries;

[Microsoft.AspNetCore.Components.Route($"{PaymentCardEndpoint.Url}")]
internal sealed class GetPaymentCard : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "payment-card",
                async ( string? accountNumber,string? serialNumber,string? uniqueKey,ISender sender) =>
                {
                    Result<GetPaymentCardResponse> result = await sender.Send(new GetPaymentCardQuery(accountNumber,serialNumber, uniqueKey));
                    
                    return result.Match(Results.Ok, ApiResults.Problem);
                }
            )
            .WithTags(PaymentCardEndpoint.Tag)
            .WithMetadata(new HttpMethodMetadata(new[] { "GET" }));
    }
}

