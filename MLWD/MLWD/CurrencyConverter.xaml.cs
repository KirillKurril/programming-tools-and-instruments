using MLWD.Services;
using System.Diagnostics;

namespace MLWD;

public partial class CurrencyConverter : ContentPage
{

    public IRateService converter;
    public CurrencyConverter()
    {

    }
    public CurrencyConverter(IRateService converter)
    {
        InitializeComponent();
        this.converter = converter;
    }
    
    public async void ConvertValueChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(FromEditor.Text))
            return;

        if (!double.TryParse(FromEditor.Text, out double convertFrom))
        {
            ToEditor.Text = "Invalid format";
            return;
        }

        if(!(CurrencySelected(FromCurrency,out string fromCurrency) && CurrencySelected(ToCurrency, out string toCurrency)))
        {
            ToEditor.Text = "Select the currency to be transferred ";
            return;
        }
        try
        {
            double rate = await Task.Run(async () 
                => { return await converter.Convert(convertFrom, fromCurrency, toCurrency, datePicker.Date); });

            ToEditor.Text = $"{rate:0.00}";
        }
        catch (HttpRequestException ex)
        {
            ToEditor.Text = "Failed to establish a connection to the server";
            Debug.WriteLine(ex.Message);
        }

    }

    private bool CurrencySelected(FlexLayout container, out string currency)
    {
        foreach (View child in container.Children)
        {
            if (child is RadioButton radioButton && radioButton.IsChecked)
            {
                currency = ((RadioButton)child).Content.ToString();
                return true;
            }
        }
        currency = string.Empty;
        return false;
    }
}
