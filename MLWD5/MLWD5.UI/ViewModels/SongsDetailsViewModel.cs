using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MLWD5.Aplication.SingerUseCases.Queries;
using MLWD5.Aplication.SongUseCases.Commands;
using MLWD5.Domain.Entities;
using MLWD5.UI.Pages;
using System.Collections.ObjectModel;
using System.Resources;

namespace MLWD5.UI.ViewModels
{
    [QueryProperty(nameof(SelectedSong), "SelectedSong")]
    public partial class SongsDetailsViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private bool _isNotEditable;
        private Song _selectedSong;
        private string _songName;
        private string _songPhotoSource;
        private string _songText;
        private string _songDescription;
        private int? _songChartPosition;
        private int? _songSingerId;
        public bool IsReadOnly => IsNotEditable;

        [ObservableProperty]
        bool confimChangesVisibility;

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
            }
        }

        public ObservableCollection<Singer> Singers { get; set; } = new();
        public ObservableCollection<string> SingersNames { get; set; } = new();

        [ObservableProperty]
        Singer songSinger;

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

        public bool IsNotEditable
        {
            get => _isNotEditable;
            set
            {
                SetProperty(ref _isNotEditable, value);
                OnPropertyChanged(nameof(IsReadOnly));
            }
        }

        public SongsDetailsViewModel(IMediator mediator)
        {
            _mediator = mediator;
            IsNotEditable = true;
        }


        [RelayCommand]
        async Task GoToPreviousPage() => await GoBack();

        [RelayCommand]
        async Task GoToCreateSong() => await AddAnotherSong();

        [RelayCommand]
        async Task DeleteSelectedSong() => await DeleteSong();

        [RelayCommand]
        async Task ChangePicture() => await SelectAnotherImage();

        [RelayCommand]
        async Task EditSelectedSong() => await EditSong();

        [RelayCommand]
        async Task ConfirmChanges() => await SaveEdits();

        [RelayCommand]
        async Task UpdateSingersList() => await GetSingers();


        private async Task GoBack()
        {
            await Shell.Current.Navigation.PopAsync();
        }

        private async Task AddAnotherSong()
        {
            await Shell.Current.GoToAsync(nameof(CreateSongView));
        }
        public async Task DeleteSong()
        {
            await _mediator.Send(new DeleteSongCommand(SelectedSong.Id));
            await Shell.Current.Navigation.PopAsync();
        }
        private async Task SelectAnotherImage()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Choose the Image"
            });

            if (result != null)
                SongPhotoSource = result.FullPath;
        }
        public async Task EditSong()
        {
            IsNotEditable = false;
            ConfimChangesVisibility = true;
        }

        public async Task SaveEdits()
        {
            { 
                await _mediator.Send(new EditSongCommand(SelectedSong.Id, SongName, SongDescription, SongText, SongChartPosition?? -1, SongPhotoSource, SongSinger.Id));
            }
            IsNotEditable = true;
            ConfimChangesVisibility = false;
        }

        public async Task GetSingers()
        {
                var singers = await _mediator.Send(new GetAllSingersRequest());
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    SingersNames.Clear();
                    Singers.Clear();
                    foreach (var singer in singers)
                    {
                        SingersNames.Add(singer.Name);
                        Singers.Add(singer);
                    }
                });
            SongSinger = singers.FirstOrDefault(singer => singer.Songs.Contains(SelectedSong));
                
        }
    }
}

