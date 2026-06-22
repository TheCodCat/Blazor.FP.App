namespace Blazor.FP.Datamodels.models.Models;

public class ForgotPasswordRequest
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public TimeSpan Offset { get; set; }
    public DateTime Created_in { get; set; }
    public ForgotPasswordResponce Responce { get; set; }
    public bool IsActive { get; set; } 

    public ForgotPasswordRequest(string login)
    {
        Id = Guid.NewGuid();
        Login = login;
        Offset = TimeSpan.FromMinutes(5);
        Created_in = DateTime.Now;
    }
}