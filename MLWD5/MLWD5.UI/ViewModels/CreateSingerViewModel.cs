using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MLWD5.Aplication.SingerUseCases.Commands;
using MLWD5.UI.Pages;
using System.Collections.ObjectModel;

namespace MLWD5.UI.ViewModels
{
    public partial class CreateSingerViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private readonly int Id;

        [ObservableProperty]
        string _singerName;

        [ObservableProperty]
        int _singerAge;

        [ObservableProperty]
        string _singerBiography;

        [ObservableProperty]
        string _singerPhotoSource;

        [RelayCommand]
        async Task GoToPreviousPage() => await GoBack();

        [RelayCommand]
        async Task ChangePicture() => await SelectAnotherImage();

        [RelayCommand]
        async Task ConfirmChanges() => await SaveEdits();


        public CreateSingerViewModel(IMediator mediator)
        {
            _mediator = mediator;
            Id = new Random().Next();
        }

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
                SingerPhotoSource = result.FullPath;
        }
        public async Task SaveEdits()
        {
            {
                await _mediator.Send(new AddSingerCommand(Id,
                                                           SingerName ?? "Not definded",
                                                           SingerAge,
                                                           SingerBiography ?? "Not definded",
                                                           SingerPhotoSource));
            }
            await Shell.Current.Navigation.PopAsync();
        }
    }
}
