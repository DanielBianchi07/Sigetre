using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Phones;

public class DeletePhoneRequest : NullableRequest
{
    [Required] 
    public long Id { get; set; }
}