using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MLWD5.Aplication.SingerUseCases.Queries;
using MLWD5.Aplication.SongUseCases.Queries;
using System.Collections.ObjectModel;

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
        public ObservableCollection<Song> Songs{ get; set; } = new();
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

        // Команда обновления списка курсов
        [RelayCommand]
        async Task UpdateSingersList() => await GetSingers();
        // Команда обновления списка слушателей курса
        [RelayCommand]
        async Task UpdateSongsList() => await GetSongs();



        public async Task GetSingers()
        {
            var singers = await _mediator.Send(new GetAllSingersRequest());
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Singers.Clear();
                foreach (var singer in singers)
                    Singers.Add(singer);
            });
        }
        public async Task GetSongs()
        {
            var songs = await _mediator.Send(new GetSongsBySingerRequest(selectedSinger.Id));
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Songs.Clear();
                foreach (var song in songs)
                    Songs.Add(song);
            });
        }
}
}