using System.Windows;

namespace VitaChildApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var bs = new BootStrapper();
            bs.Run();
        }
    }
}
