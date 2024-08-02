using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Identity;

public class RegisterRequest : NullableRequest
{
    [Required] public string Name { get; set; } = string.Empty;
    [Required] public string Telephone { get; set; } = string.Empty;
    [Required] public string Email { get; set; } = string.Empty;
    [Required] public string Password { get; set; } = string.Empty;
}