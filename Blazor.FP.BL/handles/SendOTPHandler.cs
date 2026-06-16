using Blazor.FP.BL.dtos;
using Blazor.FP.BL.request;
using Blazor.FP.Datacontext.Datacontext;
using Blazor.FP.Datamodels.models.Models;
using CSharpFunctionalExtensions;
using EF.Core.Repositories;
using EF.Core.Repositories.Extensions;
using Mapster;
using MediatR;
using PasswordGenerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.FP.BL.handles
{
    public class SendOTPHandler : IRequestHandler<SendOTPRequest, Result<ForgotPasswordResponceDto>>
    {
        private readonly IRepositoryFactory<Forgotcontext> _factory;

        public SendOTPHandler(IRepositoryFactory<Forgotcontext> factory)
        {
            _factory = factory;
        }

        public async Task<Result<ForgotPasswordResponceDto>> Handle(SendOTPRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var reposRequest = _factory.GetRepository<ForgotPasswordRequest>();
                var result = await reposRequest.InsertAsync(request.ForgotRequest);

                if (result is null)
                    return Result.Failure<ForgotPasswordResponceDto>($"database insert error {request.ForgotRequest.Email}/{request.ForgotRequest.Login}");

                await Task.Delay(5000);//аля ищим пользователя и если он есть продолжаем

                var otp = Password.ForOtp(4).Next();

                var reposResponce = _factory.GetRepository<ForgotPasswordResponce>();
                var insert = new ForgotPasswordResponce(otp, result);
                var responce = await reposResponce.InsertAsync(insert);

                return Result.Success<ForgotPasswordResponceDto>(responce.Adapt<ForgotPasswordResponceDto>());
            }
            catch(Exception ex)
            {
                return Result.Failure<ForgotPasswordResponceDto>(ex.Message);
            }
        }
    }
}
