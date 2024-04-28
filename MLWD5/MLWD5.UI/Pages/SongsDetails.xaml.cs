using MLWD5.UI.ViewModels;

namespace MLWD5.UI.Pages;

public partial class SongsDetails : ContentPage
{
    private readonly SongsDetailsViewModel _viewModel;
    public SongsDetails(SongsDetailsViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}