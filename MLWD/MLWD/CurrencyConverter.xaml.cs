using MLWD.Services;

namespace MLWD;

public partial class CurrencyConverter : ContentPage
{
	public IRateService converter;
    public CurrencyConverter(IRateService converter)
	{
		InitializeComponent();
		this.converter = converter;
	}
}