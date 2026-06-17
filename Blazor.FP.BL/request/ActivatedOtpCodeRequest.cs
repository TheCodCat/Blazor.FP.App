using CSharpFunctionalExtensions;
using MediatR;

namespace Blazor.FP.BL.request;

public class ActivatedOtpCodeRequest : IRequest<Result<bool>>
{
    public readonly int RequestId;

    public ActivatedOtpCodeRequest(int requestId)
    {
        RequestId = requestId;
    }
}