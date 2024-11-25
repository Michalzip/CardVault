using CardVault.Modules.PaymentCards.Application.PaymentCards.Commands.DeletePaymentCard;
using CardVault.Shared.Abstraction.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Components;
using CardVault.Shared.Abstraction;
using CardVault.Shared.Abstraction.Response;

namespace CardVault.Modules.PaymentCards.Api.Endpoints.PaymentCards.Commands;

[Route($"{PaymentCardEndpoint.Url}")]
internal sealed class DeletePaymentCard : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(
                "payment-card/{id}",
                async (Guid id, ISender sender) =>
                {
                    Result result =  await  sender.Send(new DeletePaymentCardCommand(id));
                    
                    return result.Match(Results.NoContent, ApiResults.Problem);
                }
            )
            .WithTags(PaymentCardEndpoint.Tag)
            .WithMetadata(new HttpMethodMetadata(new[] { "DELETE" }));
    }
}
