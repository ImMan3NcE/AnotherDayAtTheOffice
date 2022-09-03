namespace AnotherDayAtTheOffice.MVVM.Views;

public partial class Holidays : ContentPage
{
    List<string> holiDays = new List<string>();

    public Holidays()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        int numOfTodayDay1 = datePickerNameDay.Date.DayOfYear;

        base.OnAppearing();
        await LoadMauiAsset();
        holidays.Text = holiDays[numOfTodayDay1 - 1];


    }
    private void datePickerNameDay_DateSelected(object sender, DateChangedEventArgs e)
    {
        int numOfTodayDay = datePickerNameDay.Date.DayOfYear;
        holidays.Text = holiDays[numOfTodayDay - 1];
    }


    async Task LoadMauiAsset()
    {
        int numOfTodayDay2 = datePickerNameDay.Date.DayOfYear;


        if (DateTime.IsLeapYear(numOfTodayDay2))
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("Holidays.txt");
            using var reader = new StreamReader(stream);

            while (reader.Peek() != -1)
            {
                holiDays.Add(reader.ReadLine());

            }

        }
        else
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("HolidaysWO29Feb.txt");
            using var reader = new StreamReader(stream);

            while (reader.Peek() != -1)
            {
                holiDays.Add(reader.ReadLine());

            }

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