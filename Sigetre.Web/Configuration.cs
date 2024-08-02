using System.Reflection.Metadata;
using MudBlazor;

namespace Sigetre.Web;

public static class Configuration
{
    public const string HttpClientName = "sigetre";
    public static string BackendUrl { get; set; } = string.Empty;
    
    public static MudTheme Theme = new()
    {
        Typography = new Typography
        {
            Default = new Default
            {
                FontFamily = ["Raleway", "sans-serif"]
            }
        },
        PaletteLight = new PaletteLight
        {
            Primary = "#1EFA2D",
            Secondary = Colors.Gray.Darken3,
            Background = Colors.Gray.Lighten4,
            AppbarBackground = "#1EFA2D",
            AppbarText = Colors.Shades.Black,
            PrimaryContrastText = Colors.Shades.Black,
            TextPrimary = Colors.Shades.Black,
            DrawerText = Colors.Shades.Black,
            DrawerBackground = Colors.Gray.Lighten1,
        },
        PaletteDark = new PaletteDark
        {
            Primary = Colors.Gray.Darken4,
            Secondary = Colors.Gray.Default,
            Background = Colors.Gray.Lighten4,
            AppbarBackground = Colors.Gray.Darken4,
            AppbarText = Colors.Shades.White,
            PrimaryContrastText = Colors.Shades.Black,
            TextPrimary = Colors.Shades.Black,
            DrawerText = Colors.Shades.Black,
            DrawerBackground = Colors.Gray.Lighten1,
        }
    };
}