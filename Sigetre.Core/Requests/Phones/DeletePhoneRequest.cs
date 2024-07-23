using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Phones;

public class DeletePhoneRequest : Request
{
    [Required] 
    public long Id { get; set; }
    public new long? ClientId { get; set; }
}