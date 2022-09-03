using AnotherDayAtTheOffice.MVVM.ViewModels;


namespace AnotherDayAtTheOffice.MVVM.Views;

public partial class MainView : ContentPage
{
	public MainView()
	{
		InitializeComponent();
		BindingContext = new MainViewModel();
	}

	private void Button_NameDay(object sender, EventArgs e)
	{
        App.Current.MainPage = new NameDay();
    }
    private void Button_QuoteOfTheDay(object sender, EventArgs e)
    {
        App.Current.MainPage = new QuoteOfTheDay();
    }

    private void Button_Holidays(object sender, EventArgs e)
    {
        App.Current.MainPage = new Holidays();
    }

    private void Button_Proverb(object sender, EventArgs e)
    {
        App.Current.MainPage = new Proverb();
    }

    private void Button_FortuneCookie(object sender, EventArgs e)
    {
        App.Current.MainPage = new FortuneCookie();
    }
}