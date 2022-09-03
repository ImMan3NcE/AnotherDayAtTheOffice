namespace AnotherDayAtTheOffice.MVVM.Views;

public partial class Proverb : ContentPage
{
    List<string> proverbdays = new List<string>();

    
    

    public Proverb()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        int numOfTodayDay1 = datePickerNameDay.Date.DayOfYear;
        

        base.OnAppearing();
        await LoadMauiAsset();
        


        proverbs.Text = proverbdays[numOfTodayDay1];
        proverbs1.Text = proverbdays[952-numOfTodayDay1 ];



    }
    private void datePickerNameDay_DateSelected(object sender, DateChangedEventArgs e)
    {
        int numOfTodayDay = datePickerNameDay.Date.DayOfYear;
        


        proverbs.Text = proverbdays[numOfTodayDay];
        proverbs1.Text = proverbdays[952-numOfTodayDay];
    }


    async Task LoadMauiAsset()
    {
        int numOfTodayDay2 = datePickerNameDay.Date.DayOfYear;

        using var stream = await FileSystem.OpenAppPackageFileAsync("Proverbs.txt");
        using var reader = new StreamReader(stream);

        while (reader.Peek() != -1)
        {
            proverbdays.Add(reader.ReadLine());

        }

        //if (DateTime.IsLeapYear(numOfTodayDay2))
        //{
            

        //}
        //else
        //{
        //    using var stream = await FileSystem.OpenAppPackageFileAsync("NameDaysWO29Feb.txt");
        //    using var reader = new StreamReader(stream);

        //    while (reader.Peek() != -1)
        //    {
        //        proverbdays.Add(reader.ReadLine());

        //    }

        //}


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