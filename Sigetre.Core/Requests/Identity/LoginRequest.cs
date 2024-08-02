using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Identity;

public class LoginRequest : Request
{
    [Required]
    public string Email { get; set; } = string.Empty;

    [Required] 
    public string Password { get; set; } = string.Empty;
}