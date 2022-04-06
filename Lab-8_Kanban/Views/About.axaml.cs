using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Lab_8_Kanban.Views
{
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

