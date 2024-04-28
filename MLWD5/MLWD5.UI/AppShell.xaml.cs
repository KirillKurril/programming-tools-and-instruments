using MLWD5.UI.Pages;

namespace MLWD5.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Singers), typeof(Singers));
            Routing.RegisterRoute(nameof(SongsDetails), typeof(SongsDetails));
            Routing.RegisterRoute(nameof(EditSingerView), typeof(EditSingerView));
            Routing.RegisterRoute(nameof(CreateSongView), typeof(CreateSongView));
            Routing.RegisterRoute(nameof(CreateSingerView), typeof(CreateSingerView));
        }
    }
}
