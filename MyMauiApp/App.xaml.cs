using Microsoft.Maui.Controls;

namespace MyMauiApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
