using System;

namespace AnotherDayAtTheOffice.MVVM.Views;

public partial class FortuneCookie : ContentPage
{
    List<string> fortune = new List<string>();
    Random rnd = new Random();

    int a = 0;
    public FortuneCookie()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadMauiAsset();
    }


    async Task LoadMauiAsset()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("Fortune.txt");
        using var reader = new StreamReader(stream);

        while (reader.Peek() != -1)
        {
            fortune.Add(reader.ReadLine());

        }
    }


    private void Button_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new MainView();
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        if (a == 0)
        {
            a++;
            CookieButton.Source = "fortunecookie2.png";
            TxtCookie.Text = "Ju¿ prawie, uderz jeszcze raz!";
        }
        else if (a == 1)
        {
            int index = rnd.Next(fortune.Count);
            CookieButton.Source = "fortunecookie3.png";
            TxtCookie.Text = fortune[index];
            a++;
        }
        else if (a == 2)
        {

            a = 0;
            CookieButton.Source = "fortunecookie.png";
            TxtCookie.Text = "Uderz w ciastko! :)";

        }
        //int index = random.Next(fortune.Count);
    }
}