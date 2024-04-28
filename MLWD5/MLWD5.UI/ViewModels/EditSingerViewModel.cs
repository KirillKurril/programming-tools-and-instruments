using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MLWD5.Aplication.SingerUseCases.Commands;
using MLWD5.Aplication.SongUseCases.Commands;
using MLWD5.Aplication.SongUseCases.Queries;
using MLWD5.UI.Pages;
using System.Collections.ObjectModel;

namespace MLWD5.UI.ViewModels
{
    public partial class EditSingerViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private Singer _selectedSinger;

        public Singer SelectedSinger
        {
            get => _selectedSinger;
            set
            {
                SetProperty(ref _selectedSinger, value);
                SingerName = SelectedSinger.Name;
                SingerAge = SelectedSinger.Age ?? 0;
                SingerBiography = SelectedSinger.Biography;
                SingerPhotoSource = SelectedSinger.PhotoSource;
            }
        }

        [ObservableProperty]
        Song _selectedSong;

        [ObservableProperty]
        string _singerName;

        [ObservableProperty]
        int _singerAge;

        [ObservableProperty]
        string _singerBiography;

        [ObservableProperty]
        string _singerPhotoSource;
        public ObservableCollection<Song> SingerSongs { get; set; } = new();

        [RelayCommand]
        async Task UpdateSongsList() => await GetSongs();

        [RelayCommand]
        async Task GoToPreviousPage() => await GoBack();

        [RelayCommand]
        async Task GoToCreateSong() => await AddAnotherSong();

        [RelayCommand]
        async Task DeleteSelectedSinger() => await DeleteSinger();
        
        [RelayCommand]
        async Task DeleteSelectedSong() => await DeleteSong();

        [RelayCommand]
        async Task ChangePicture() => await SelectAnotherImage();

        [RelayCommand]
        async Task ConfirmChanges() => await SaveEdits();



        public EditSingerViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task GetSongs()
        {
            var songs = await _mediator.Send(new GetSongsBySingerRequest(SelectedSinger.Id));
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                SingerSongs.Clear();
                foreach (var song in songs)
                    SingerSongs.Add(song);

                SelectedSong = songs.FirstOrDefault();
            });

        }

        private async Task GoBack()
        {
            await Shell.Current.Navigation.PopAsync();
        }
        private async Task AddAnotherSong()
        {
            await Shell.Current.GoToAsync(nameof(CreateSongView));
            await GetSongs();
        }
        public async Task DeleteSinger()
        {
            await _mediator.Send(new DeleteSingerCommand(SelectedSinger.Id));
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
                SingerPhotoSource = result.FullPath;
        }
        public async Task SaveEdits()
        {
            {
                await _mediator.Send(new EditSingerCommand(SelectedSinger.Id,
                                                           SingerName,
                                                           SingerAge,
                                                           SingerBiography,
                                                           SingerPhotoSource));
            }
            await Shell.Current.Navigation.PopAsync();
        }
        public async Task DeleteSong()
        {
            await _mediator.Send(new DeleteSongCommand(SelectedSong.Id));
            await GetSongs();
        }
    }
}
