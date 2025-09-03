using CLISimplified.Pages;

namespace CLISimplified
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CLiInterface), typeof(CLiInterface));
        }
    }
}
