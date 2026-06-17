namespace Blazor.FP.Datamodels.models.Models;

public class ForgotPasswordResponce
{
    private ForgotPasswordResponce() { }
    public int Id { get; set; }
    public string OTPCode { get; set; }
    public int RequestId { get; set; }
    public ForgotPasswordRequest Request { get; set; }

    public ForgotPasswordResponce(string otpCode, ForgotPasswordRequest request)
    {
        OTPCode = otpCode;
        Request = request;
    }
}