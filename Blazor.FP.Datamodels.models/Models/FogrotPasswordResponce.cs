namespace Blazor.FP.Datamodels.models.Models;

public class FogrotPasswordResponce
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string OTPCode { get; set; }
    public TimeSpan Offset { get; set; }
}