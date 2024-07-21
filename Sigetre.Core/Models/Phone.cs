using Sigetre.Core.Enums;

namespace Sigetre.Core.Models;

public class Phone
{
    // fields
    public long Id { get; set; }
    public string Number { get; set; } = String.Empty;
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public EStatus Status { get; set; }
    public long CreatedBy { get; set; }
    public long? UpdatedBy { get; set; }
    
    
    public long? CompanyId { get; set; }
    public Company Company { get; set; } = null!;
    public long? ClientId { get; set; }
    public Client Client { get; set; } = null!;
}