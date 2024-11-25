
using CardVault.Shared.Abstraction.Endpoints;
using Microsoft.AspNetCore.Components;

namespace CardVault.Modules.PaymentCards.Api.Endpoints.DeviceCards.Commands;

[Route($"{DeviceCardsEndpoint.Url}")]
internal sealed class GeneratePaymentCard : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "generate-payment-card",
                async () =>
                {

                    await Task.Delay(10000);
                    
                    return Results.Ok(new { Message = "cards are generated" });
                }
            )
            .WithTags(DeviceCardsEndpoint.Tag)
            .WithMetadata(new HttpMethodMetadata(new[] { "POST" }));
    }

 
}
