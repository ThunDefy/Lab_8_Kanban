using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Lab_8_Kanban.ViewModels;
using Lab_8_Kanban.Views;

namespace Lab_8_Kanban
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
                (desktop.MainWindow.DataContext as MainWindowViewModel).show = desktop.MainWindow;
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
