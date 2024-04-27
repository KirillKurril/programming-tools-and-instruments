using MLWD5.UI.Pages;

namespace MLWD5.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SongsDetails), typeof(SongsDetails));
        }
    }
}
