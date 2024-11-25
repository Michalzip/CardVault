namespace CardVault.UI;

using CardVault.UI.View;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new HomePage());
    }
}
