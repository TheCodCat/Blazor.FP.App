using CSharpFunctionalExtensions;
using MediatR;

namespace Blazor.FP.BL.request;

public class ActivatedOtpCodeRequest : IRequest<Result<bool>>
{
    public readonly Guid RequestId;

    public ActivatedOtpCodeRequest(Guid requestId)
    {
        RequestId = requestId;
    }
}