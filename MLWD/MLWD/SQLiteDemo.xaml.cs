using System;
using MLWD.Entities;

namespace MLWD;

public partial class SQLiteDemo : ContentPage
{
    MuseumDataBase museumData;
    List<MuseumHall> halls;
    Picker picker;

    public SQLiteDemo()
    {
        InitializeComponent();
        museumData = new MuseumDataBase();
        Loaded += FullfillPicker;
    }

    public void HallIdChenged(object sender, EventArgs e)
    {
        StackLayout stack = (StackLayout)FindByName("SearchResultContainer");
        stack.Children.Clear();
        string selectedOption = picker.SelectedItem.ToString();
        List<Exhibit> exibits = museumData.GetExhibitsByHallName(selectedOption);
        foreach(Exhibit exibit in exibits)
        {
            Label exibitLabel = new Label
            {
                Text = exibit.Name,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 10, 0, 10),
            };
            stack.Children.Add(exibitLabel);
        }
    }

    public void FullfillPicker(object sender, EventArgs e)
    {
        halls = museumData.GetHalls();

        List<string> hallNames = halls.Select(h => h.Name).ToList();

        picker = (Picker)FindByName("HallsPicker");

        picker.ItemsSource = hallNames;
    }
}
