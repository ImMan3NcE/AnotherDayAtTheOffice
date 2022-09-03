


namespace AnotherDayAtTheOffice.MVVM.Views;

public partial class QuoteOfTheDay : ContentPage
{
    List<string> quotedays = new List<string>();
    List<string> quotedaysAuthor = new List<string>();





    public QuoteOfTheDay()
    {
        InitializeComponent();

    }


    protected override async void OnAppearing()
    {
        int numOfTodayDay1 = datePickerNameDay.Date.DayOfYear;

        base.OnAppearing();
        await LoadMauiAsset();
        quotes.Text = quotedays[numOfTodayDay1 - 1];
        quoteAuthor.Text = "- " + quotedaysAuthor[numOfTodayDay1 - 1] + "- ";

    }
    private void datePickerNameDay_DateSelected(object sender, DateChangedEventArgs e)
    {
        int numOfTodayDay = datePickerNameDay.Date.DayOfYear;
        quotes.Text = quotedays[numOfTodayDay - 1];
        quoteAuthor.Text = "- " + quotedaysAuthor[numOfTodayDay - 1] + "- ";
    }


    async Task LoadMauiAsset()
    {
           using var stream = await FileSystem.OpenAppPackageFileAsync("QuotesA.txt");
            using var reader = new StreamReader(stream);

            while (reader.Peek() != -1)
            {
                quotedays.Add(reader.ReadLine());

            }

        using var stream2 = await FileSystem.OpenAppPackageFileAsync("QuotesAuthors.txt");
        using var reader2 = new StreamReader(stream2);

        while (reader2.Peek() != -1)
        {
            quotedaysAuthor.Add(reader2.ReadLine());

        }



    }

    private void Button_Clicked(object sender, EventArgs e)
    {

        App.Current.MainPage = new MainView();

    }
    private void Button_Next(object sender, EventArgs e)
    {
        datePickerNameDay.Date = datePickerNameDay.Date.AddDays(1);
    }
    private void Button_Previous(object sender, EventArgs e)
    {
        datePickerNameDay.Date = datePickerNameDay.Date.AddDays(-1);
    }

}