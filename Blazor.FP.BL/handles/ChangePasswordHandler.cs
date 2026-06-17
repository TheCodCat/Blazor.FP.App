using Blazor.FP.BL.dtos;
using Blazor.FP.BL.request;
using Blazor.FP.Datacontext.Datacontext;
using CSharpFunctionalExtensions;
using EF.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.FP.BL.handles
{
    public class ChangePasswordHandler : IRequestHandler<ChangePasswordRequest, Result<ChangePasswordResponce>>
    {
        private readonly IRepositoryFactory<Forgotcontext> _factory;

        public ChangePasswordHandler(IRepositoryFactory<Forgotcontext> factory)
        {
            _factory = factory;
        }

        public async Task<Result<ChangePasswordResponce>> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await Task.Delay(7000);
                
                var result = new ChangePasswordResponce() { Login = request.Dto.Login, RequestId = request.Dto.Id, Result = true };
                
                //аля запрос на изменение пароля

                return Result.Success<ChangePasswordResponce>(result);
            }
            catch (Exception ex)
            {
                return Result.Failure<ChangePasswordResponce>(ex.Message);
            }
        }
    }
}
