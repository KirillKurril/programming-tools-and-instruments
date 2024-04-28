using MLWD5.UI.ViewModels;

namespace MLWD5.UI.Pages;

public partial class CreateSongView : ContentPage
{
    private readonly CreateSongViewModel _viewModel;
    public CreateSongView(CreateSongViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}