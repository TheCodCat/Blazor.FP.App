using Blazor.FP.BL.request;
using Blazor.FP.Datacontext.Datacontext;
using Blazor.FP.Datamodels.models.Models;
using CSharpFunctionalExtensions;
using EF.Core.Repositories;
using EF.Core.Repositories.Extensions;
using MediatR;

namespace Blazor.FP.BL.handles;

public class ActivatedOtpCodehandler : IRequestHandler<ActivatedOtpCodeRequest, Result<bool>>
{
    private readonly IRepositoryFactory<Forgotcontext> _factory;

    public ActivatedOtpCodehandler(IRepositoryFactory<Forgotcontext> factory)
    {
        _factory = factory;
    }
    
    public async Task<Result<bool>> Handle(ActivatedOtpCodeRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var repos = _factory.GetRepository<ForgotPasswordRequest>();
            var item = await repos.GetAsync(new {
                Id = request.RequestId
            });

            if (item != null)
                item.IsActive = true;
            
            await repos.UpdateAsync(item);
            
            return Result.Success(true);
        }
        catch (Exception e)
        {
            return Result.Failure<bool>(e.Message);
        }
    }
}