using CommunityToolkit.Mvvm.ComponentModel;

namespace MLWD5.UI.ViewModels
{
    public partial class CreateSingerViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public CreateSingerViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
