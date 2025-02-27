using ProductMonitor.ViewModels;
using System.Threading.Tasks.Sources;
using System.Windows;

namespace ProductMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var mainWindowViewModel = new MainWindowViewModel();
            this.DataContext = mainWindowViewModel;
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Min_Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

    }
}