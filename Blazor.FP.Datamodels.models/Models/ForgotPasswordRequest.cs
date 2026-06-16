namespace Blazor.FP.Datamodels.models.Models;

public class ForgotPasswordRequest
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public ForgotPasswordResponce Responce { get; set; }
}