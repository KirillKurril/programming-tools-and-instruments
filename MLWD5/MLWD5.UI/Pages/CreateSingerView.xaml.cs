using MLWD5.UI.ViewModels;

namespace MLWD5.UI.Pages;

public partial class CreateSingerView : ContentPage
{
    private readonly CreateSingerViewModel _viewModel;
    public CreateSingerView(CreateSingerViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}