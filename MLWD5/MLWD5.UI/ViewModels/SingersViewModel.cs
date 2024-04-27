using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MLWD5.Aplication.SingerUseCases.Queries;
using MLWD5.Aplication.SongUseCases.Queries;
using MLWD5.UI.Pages;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MLWD5.UI.ViewModels
{
    public partial class SingersViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public SingersViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public ObservableCollection<Singer> Singers { get; set; } = new();
        public ObservableCollection<string> SingersNames { get; set; } = new();
        public ObservableCollection<Song> Songs{ get; set; } = new();
        public ObservableCollection<string> SongNames { get; set; } = new();

        // Выбранный в списке курс
        [ObservableProperty]
        Singer selectedSinger;

        string _selectedSingerName;
        public string SelectedSingerName
        {
            get { return _selectedSingerName; }
            set
            {
                SetProperty(ref _selectedSingerName, value);
                UpdateSongsList();
            }
        }

        
        [RelayCommand]
        async Task UpdateSingersList() => await GetSingers();
        
        [RelayCommand]
        async Task UpdateSongsList() => await GetSongs();

        [RelayCommand]
        async void ShowDetails(Song song) => await GotoDetailsPage(song);

        public async Task GetSingers()
        {
            try
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
                selectedSinger = Singers.FirstOrDefault();
                SelectedSingerName = selectedSinger.Name;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        public async Task GetSongs()
        {
            try
            {
                var songs = await _mediator.Send(new GetSongsBySingerRequest(selectedSinger.Id));
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    Songs.Clear();
                    SongNames.Clear();
                    foreach (var song in songs)
                    {
                        SongNames.Add(song.Name);
                        Songs.Add(song);
                    }
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private async Task GotoDetailsPage(Song song)
        {
            IDictionary<string, object> parameters =
                new Dictionary<string, object>() {{ "SelectedSong", song}};
            
            await Shell.Current.GoToAsync(nameof(SongsDetails), parameters);
        }
    }
}