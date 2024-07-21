namespace Sigetre.Api.Models;

public class RegisterModel
{
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public long? ClientId { get; set; }
}