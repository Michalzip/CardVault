using CardVault.Modules.PaymentCards.Application.PaymentCards.Commands.AddPaymentCard;
using CardVault.Shared.Abstraction;
using CardVault.Shared.Abstraction.Endpoints;
using CardVault.Shared.Abstraction.Response;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace CardVault.Modules.PaymentCards.Api.Endpoints.PaymentCards.Commands;

[Route($"{PaymentCardEndpoint.Url}")]
internal sealed class AddPaymentCard : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "payment-card",
                async (ISender sender,Request request) =>
                {
                    Result<String> result =   await  sender.Send(new AddPaymentCardCommand(request.AccountNumber, request
                        .Pin, request.SerialNumber));
                    
                    return result.Match(Results.Ok, ApiResults.Problem);
                    
                }
            )
            .WithTags(PaymentCardEndpoint.Tag)
            .WithMetadata(new HttpMethodMetadata(new[] { "POST" }));
    }

    sealed class Request
    {
        public string AccountNumber { get; set; } 
        public string Pin { get; set; } 
        public string SerialNumber { get; set; } 
    }
}
