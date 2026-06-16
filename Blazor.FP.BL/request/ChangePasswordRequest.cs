using Blazor.FP.BL.dtos;
using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.FP.BL.request
{
    public class ChangePasswordRequest : IRequest<Result<ChangePasswordResponce>>
    {
        public readonly ForgotPasswordRequestDto Dto;

        public ChangePasswordRequest(ForgotPasswordRequestDto dto)
        {
            Dto = dto;
        }
    }
}
