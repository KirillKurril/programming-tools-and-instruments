using CommunityToolkit.Mvvm.ComponentModel;

namespace MLWD5.UI.ViewModels
{
    public partial class CreateSongViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public CreateSongViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
