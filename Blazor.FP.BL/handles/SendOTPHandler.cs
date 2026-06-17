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
using Flurl;
using Flurl.Http;

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
                    return Result.Failure<ForgotPasswordResponceDto>($"database insert error {request.ForgotRequest.Login}");


                var otp = Password.ForOtp(4).Next();
                var reposResponce = _factory.GetRepository<ForgotPasswordResponce>();
                var insert = new ForgotPasswordResponce(otp, result);
                var responce = await reposResponce.InsertAsync(insert);
                
                var responceSend = await new Url("https://mfc.samgk.ru/forgot-password/send-otp")
                    .SetQueryParams(new
                    {
                        otp = otp,
                        login = request.ForgotRequest.Login,
                        request = request.ForgotRequest.Id,
                        timeout = request.ForgotRequest.Offset,
                        createdAt = request.ForgotRequest.Created_in,
                    })
                    .GetJsonAsync<ForgotPasswordResponceDto>();
                
                
                return Result.Success<ForgotPasswordResponceDto>(responceSend);
            }
            catch(FlurlHttpException ex)
            {
                var mess = await ex.GetResponseStringAsync();
                return Result.Failure<ForgotPasswordResponceDto>(ex.Message);
            }
        }
    }
}
