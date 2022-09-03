namespace AnotherDayAtTheOffice.MVVM.Views;

public partial class NameDay : ContentPage
{
    List<string> namedays = new List<string>();
    public NameDay()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        int numOfTodayDay1 = datePickerNameDay.Date.DayOfYear;

        base.OnAppearing();
        await LoadMauiAsset();
        names.Text = namedays[numOfTodayDay1 - 1];


    }
    private void datePickerNameDay_DateSelected(object sender, DateChangedEventArgs e)
    {
        int numOfTodayDay = datePickerNameDay.Date.DayOfYear;
        names.Text = namedays[numOfTodayDay - 1];
    }


    async Task LoadMauiAsset()
    {
        int numOfTodayDay2 = datePickerNameDay.Date.DayOfYear;


        if (DateTime.IsLeapYear(numOfTodayDay2))
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("NameDays.txt");
            using var reader = new StreamReader(stream);

            while (reader.Peek() != -1)
            {
                namedays.Add(reader.ReadLine());

            }

        }
        else
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("NameDaysWO29Feb.txt");
            using var reader = new StreamReader(stream);

            while (reader.Peek() != -1)
            {
                namedays.Add(reader.ReadLine());

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