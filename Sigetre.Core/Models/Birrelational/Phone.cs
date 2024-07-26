namespace Sigetre.Core.Models.Birrelational;

public class Phone : BaseNullableClass
{
    // fields
    public long Id { get; set; }
    public string Number { get; set; } = String.Empty;
    
    public Company Company { get; set; } = null!;
    public Client Client { get; set; } = null!;
}