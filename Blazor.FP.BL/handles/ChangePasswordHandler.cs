using Blazor.FP.BL.dtos;
using Blazor.FP.BL.request;
using Blazor.FP.Datacontext.Datacontext;
using CSharpFunctionalExtensions;
using EF.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;

namespace Blazor.FP.BL.handles
{
    public class ChangePasswordHandler : IRequestHandler<ChangePasswordRequest, Result<ChangePasswordResponce>>
    {
        private readonly IRepositoryFactory<Forgotcontext> _factory;
        private readonly IFlurlClient _client;

        public ChangePasswordHandler(IRepositoryFactory<Forgotcontext> factory, IFlurlClient client )
        {
            _factory = factory;
            _client = client;
        }

        public async Task<Result<ChangePasswordResponce>> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var changePass = await _client.Request("forgot-password/change-password")
                    .PostJsonAsync(new
                    {
                        password = request.Dto.Password,
                        login = request.Dto.Login,
                    }, cancellationToken: cancellationToken).ReceiveJson<ChangePasswordResponce>();

                return Result.Success<ChangePasswordResponce>(changePass);
            }
            catch (FlurlHttpException ex)
            {
                return Result.Failure<ChangePasswordResponce>(await ex.Call.Response.GetStringAsync());
            }
        }
    }
}
