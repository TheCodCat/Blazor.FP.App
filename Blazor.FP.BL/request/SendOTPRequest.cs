using Blazor.FP.BL.dtos;
using Blazor.FP.Datamodels.models.Models;
using CSharpFunctionalExtensions;
using MediatR;

namespace Blazor.FP.BL.request
{
    public class SendOTPRequest : IRequest<Result<ForgotPasswordResponceDto>>
    {
        public readonly ForgotPasswordRequest ForgotRequest;

        public SendOTPRequest(ForgotPasswordRequest forgotRequest)
        {
            ForgotRequest = forgotRequest;
        }
    }
}
