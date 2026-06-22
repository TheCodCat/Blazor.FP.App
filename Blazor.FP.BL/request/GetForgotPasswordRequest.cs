using Blazor.FP.BL.dtos;
using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.FP.BL.request
{
    public class GetForgotPasswordRequest : IRequest<Result<ForgotPasswordRequestDto>>
    {
        public readonly Guid RequestId;

        public GetForgotPasswordRequest(Guid requestId)
        {
            RequestId = requestId;
        }
    }
}
