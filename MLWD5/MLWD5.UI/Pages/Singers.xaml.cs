using MLWD5.UI.ViewModels;

namespace MLWD5.UI.Pages;

public partial class Singers : ContentPage
{
    private readonly SingersViewModel _viewModel;
    public Singers(SingersViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}