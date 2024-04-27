using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MLWD5.Aplication.SongUseCases.Commands;

namespace MLWD5.UI.ViewModels
{
    [QueryProperty(nameof(SelectedSong), "SelectedSong")]
    public partial class SongsDetailsViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private bool _isEditable;
        private Song _selectedSong;
        private string _songName;
        private string _songPhotoSource;
        private string _songPhotoTitle;
        private string _songText;
        private string _songDescription;
        private int? _songChartPosition;
        private int? _songSingerId;

        public Song SelectedSong
        {
            get => _selectedSong;
            set
            {
                SetProperty(ref _selectedSong, value);
                SongChartPosition = SelectedSong.ChartPosition;
                SongPhotoSource = SelectedSong.PhotoSource;
                SongName = SelectedSong.Name;
                SongDescription = SelectedSong.Description;
                SongText = SelectedSong.Text;
                SongSingerId = SelectedSong.SingerId;
            }
        }

        public string SongName
        {
            get => _songName;
            set => SetProperty(ref _songName, value);
        }

        public int? SongChartPosition
        {
            get => _songChartPosition;
            set => SetProperty(ref _songChartPosition, value);
        }

        public string? SongDescription
        {
            get => _songDescription;
            set => SetProperty(ref _songDescription, value);
        }

        public string? SongPhotoSource
        {
            get => _songPhotoSource;
            set => SetProperty(ref _songPhotoSource, value);
        }

        public string? SongText
        {
            get => _songText;
            set => SetProperty(ref _songText, value);
        }

        public int? SongSingerId
        {
            get => _songSingerId;
            set => SetProperty(ref _songSingerId, value);
        }

        public bool IsEditable
        {
            get => _isEditable;
            set
            {
                SetProperty(ref _isEditable, value);
                OnPropertyChanged(nameof(IsReadOnly));
            }
        }

        public SongsDetailsViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }


        [RelayCommand]
        async Task EditSongsDetailes() => await EditSong();

        [RelayCommand]
        async Task SaveSongsDetailesEdits() => await SaveEdits();

        [RelayCommand]
        async Task DeleteSongsDetailes() => await DeleteSong();

        public bool IsReadOnly => !IsEditable;

        public async Task EditSong()
        {
            IsEditable = true;
        }

        public async Task SaveEdits()
        {
            { 
                await _mediator.Send(new EditSongCommand(SelectedSong.Id, SongName, SongDescription, SongText, SongChartPosition?? -1, SongSingerId??-1));
            }

            IsEditable = false;
        }

        public async Task DeleteSong()
        {
            await _mediator.Send(new DeleteSongCommand(SelectedSong.Id));
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}

