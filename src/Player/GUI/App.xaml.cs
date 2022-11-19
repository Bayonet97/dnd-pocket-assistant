using DndPocketAssistant.Player.GUI.Main;
using System.Windows;

namespace DndPocketAssistant.Player.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow = new MainView();
            MainWindow.DataContext = new MainViewModel();
            MainWindow.Show();
        }
    }
}
