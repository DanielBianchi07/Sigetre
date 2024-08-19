namespace Sigetre.Core.Models.Birrelational;

public class Phone : BaseClass
{
    // fields
    public long Id { get; set; }
    public string Number { get; set; } = String.Empty;
    
    public long CompanyId { get; set; }
    public Company Company { get; set; } = null!;
}