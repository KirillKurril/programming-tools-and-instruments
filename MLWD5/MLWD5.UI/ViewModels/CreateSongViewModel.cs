using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MLWD5.Aplication.SingerUseCases.Queries;
using MLWD5.Aplication.SongUseCases.Commands;
using MLWD5.UI.Pages;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MLWD5.UI.ViewModels
{
    public partial class CreateSongViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private string _songName;
        private string _songPhotoSource;
        private string _songText;
        private string _songDescription;
        private int? _songChartPosition;
        private int _songSingerId;
        private readonly int Id;
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

        public int SongSingerId
        {
            get => _songSingerId;
            set => SetProperty(ref _songSingerId, value);
        }

        public CreateSongViewModel(IMediator mediator)
        {
            _mediator = mediator;
            Id = new Random().Next();
        }


        [RelayCommand]
        async Task GoToPreviousPage() => await GoBack();

        [RelayCommand]
        async Task ChangePicture() => await SelectAnotherImage();

        [RelayCommand]
        async Task ConfirmChanges() => await SaveEdits();

        [RelayCommand]
        async Task UpdateSingersList() => await GetSingers();


        private async Task GoBack()
        {
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
        public async Task SaveEdits()
        {
            try
            {
                await _mediator.Send(new AddSongToSingerCommand
                    (Id,
                    SongName ?? "Not definded",
                    SongDescription ?? "Not definded",
                    SongText ?? "Not definded",
                    SongChartPosition ?? -1,
                    SongPhotoSource,
                    SongSinger.Id));
                
                var song = new Song(SongName ?? "Not definded",
                                    SongDescription ?? "Not definded",
                                    SongText ?? "Not definded",
                                    SongChartPosition ?? -1,
                                    Id,
                                    SongPhotoSource,
                                    SongSingerId);

                IDictionary<string, object> parameters =
                        new Dictionary<string, object>() { { "SelectedSong", song } };

                await Shell.Current.Navigation.PopAsync();
                await Shell.Current.GoToAsync(nameof(SongsDetails), parameters);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            
        }

        public async Task GetSingers()
        {
            var singers = await _mediator.Send(new GetAllSingersRequest());
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Singers.Clear();
                foreach (var singer in singers)
                {
                    SingersNames.Add(singer.Name);
                    Singers.Add(singer);
                }
                SongSinger = Singers.FirstOrDefault();
            });

        }
    }
}

