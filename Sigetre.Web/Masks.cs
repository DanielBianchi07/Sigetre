using MudBlazor;

namespace Sigetre.Web;

public class Masks
{
    public PatternMask CNPJMask = new PatternMask("##.###.###/XXX#-##")
    {
        MaskChars = new [] {new MaskChar('X', "[0]"), new MaskChar('#', @"[0-9a]")},
        Placeholder = '0'
    };
    
    public PatternMask TelephoneMask = new PatternMask("(##) # ####-####")
    {
        MaskChars = new [] {new MaskChar('#', @"[0-9a]")},
        Placeholder = '0'
    };
    
    public PatternMask CPFMask = new PatternMask("###.###.###-##")
    {
        MaskChars = new [] {new MaskChar('#', @"[0-9a]")},
        Placeholder = '0'
    };
}