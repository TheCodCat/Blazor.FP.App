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
using Microsoft.Extensions.Logging;

namespace Blazor.FP.BL.handles
{
    public class SendOTPHandler : IRequestHandler<SendOTPRequest, Result<ForgotPasswordResponceDto>>
    {
        private readonly IRepositoryFactory<Forgotcontext> _factory;
        private  readonly IFlurlClient _client;
        private readonly ILogger _logger;

        public SendOTPHandler(IRepositoryFactory<Forgotcontext> factory, IFlurlClient flurlClient,  ILogger logger)
        {
            _factory = factory;
            _client = flurlClient;
            _logger = logger;
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
                
                _logger.LogInformation($"{request.ForgotRequest.Id}/отправка");
                var responceSend = await _client
                    .Request("forgot-password/send-otp")
                    .SetQueryParams(new
                    {
                        otp = otp,
                        login = request.ForgotRequest.Login,
                        request = request.ForgotRequest.Id,
                        timeout = request.ForgotRequest.Offset,
                        createdAt = request.ForgotRequest.Created_in,
                    })
                    .GetJsonAsync<ForgotPasswordResponceDto>();
                
                _logger.LogInformation($"{responceSend.Message}/{responceSend.RequestId}");
                return Result.Success<ForgotPasswordResponceDto>(responceSend);
            }
            catch(FlurlHttpException ex)
            {
                var mess = await ex.GetResponseStringAsync();
                _logger.LogWarning($"{mess}");
                return Result.Failure<ForgotPasswordResponceDto>(ex.Message);
            }
        }
    }
}
