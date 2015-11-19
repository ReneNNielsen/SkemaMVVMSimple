using System.Windows;
using ViewModels;

namespace SkemaMVVM.DesktopClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainViewModel ViewModel = new MainViewModel();
            var window = new Views.MainWindow
            {
                DataContext = ViewModel
            };

            window.ShowDialog();
        }
    }
}
