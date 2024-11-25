using CardVault.UI.Services;
using CardVault.UI.View;
using CardVault.UI.ViewModels;
using CommunityToolkit.Maui;

namespace CardVault.UI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("Poppins-Regular.ttf");
            });

        return builder.Build();
    }
}
