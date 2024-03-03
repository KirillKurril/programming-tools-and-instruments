using System;
using MLWD.Entities;
using MLWD.Services;

namespace MLWD;

public partial class SQLiteDemo : ContentPage
{
    IDbService<MuseumHall, Exhibit> museumData;
    List<MuseumHall> halls;
    Picker picker;

    public SQLiteDemo(IDbService<MuseumHall, Exhibit> museumData)
    {
        InitializeComponent();
        this.museumData = museumData;
        Loaded += FullfillPicker;
    }

    public void HallIdChenged(object sender, EventArgs e)   
    {
        if(!(picker.SelectedItem == null))
        {
            ClearStack();
            StackLayout stack = (StackLayout)FindByName("SearchResultContainer");

            int id = halls.FirstOrDefault(e => e.Name == picker.SelectedItem.ToString()).Id;

            List<Exhibit> exibits = museumData.GetExhibitsByHall(id).ToList();
            foreach (Exhibit exibit in exibits)
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
    }

    public void FullfillPicker(object sender, EventArgs e)
    {
        ClearStack();
        halls = museumData.GetHalls().ToList();
        List<string> hallNames = halls.Select(h => h.Name).ToList();
        picker = (Picker)FindByName("HallsPicker");
        picker.ItemsSource = hallNames;
    }
    private void ClearStack()
    {
        StackLayout stack = (StackLayout)FindByName("SearchResultContainer");
        stack.Children.Clear();
    }
}
