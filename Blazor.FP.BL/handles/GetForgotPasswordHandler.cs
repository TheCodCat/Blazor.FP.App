using Blazor.FP.BL.dtos;
using Blazor.FP.BL.request;
using Blazor.FP.Datacontext.Datacontext;
using Blazor.FP.Datamodels.models.Models;
using CSharpFunctionalExtensions;
using EF.Core.Repositories;
using EF.Core.Repositories.Extensions;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.FP.BL.handles
{
    internal class GetForgotPasswordHandler : IRequestHandler<GetForgotPasswordRequest, Result<ForgotPasswordRequestDto>>
    {
        private readonly IRepositoryFactory<Forgotcontext> _factory;

        public GetForgotPasswordHandler(IRepositoryFactory<Forgotcontext> factory)
        {
            _factory = factory;
        }

        public async Task<Result<ForgotPasswordRequestDto>> Handle(GetForgotPasswordRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var repos = _factory.GetReadOnlyRepository<ForgotPasswordRequest>();
                var getRequest = await repos.GetAsync(new { Id = request.RequestId });

                if (getRequest is null)
                    return Result.Failure<ForgotPasswordRequestDto>("Произошла ошибка при поиске заявки");
                else
                {
                    return Result.Success<ForgotPasswordRequestDto>(getRequest.Adapt<ForgotPasswordRequestDto>());
                }
            }
            catch(Exception ex)
            {
                return Result.Failure<ForgotPasswordRequestDto>(ex.Message);
            }
        }
    }
}
