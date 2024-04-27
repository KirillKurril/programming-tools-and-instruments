using CommunityToolkit.Mvvm.ComponentModel;

namespace MLWD5.UI.ViewModels
{
    public partial class EditSingerViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public EditSingerViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
