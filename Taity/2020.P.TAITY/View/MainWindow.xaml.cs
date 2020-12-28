using _2020.P.TAITY.Services;
using _2020.P.TAITY.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace _2020.P.TAITY.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.Service = MainFrame.NavigationService;

            DataContext = new MainViewModel(new ViewModelsResolver());
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }
    }
}
