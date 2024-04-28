using MLWD5.UI.ViewModels;

namespace MLWD5.UI.Pages;

public partial class EditSingerView : ContentPage
{
    private readonly EditSingerViewModel _viewModel;
    public EditSingerView(EditSingerViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}