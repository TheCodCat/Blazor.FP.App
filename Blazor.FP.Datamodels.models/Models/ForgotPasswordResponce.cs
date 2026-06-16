namespace Blazor.FP.Datamodels.models.Models;

public class ForgotPasswordResponce
{
    public int Id { get; set; }
    public string OTPCode { get; set; }
    public TimeSpan Offset { get; set; }
    public int RequestId { get; set; }
    public ForgotPasswordRequest Request { get; set; }
}