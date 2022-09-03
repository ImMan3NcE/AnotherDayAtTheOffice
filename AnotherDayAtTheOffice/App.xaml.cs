using AnotherDayAtTheOffice.MVVM.Views;

namespace AnotherDayAtTheOffice;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new MainView();
	}
}
