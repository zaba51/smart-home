using SmartHome.ControlPanel;
using SmartHome.ControlPanel.AutoController;
using SmartHome.ControlPanel.DevicePanel;
using SmartHome.ControlPanel.Service;
using SmartHome.DeviceGrid;
using SmartHome.Devices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartHome
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DevicePanel DevicePanel { get; private set; }
        public ControlPanel.ControlPanel ControlPanel { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            var autoController = new AutoController();
            DevicePanel = new DevicePanel(autoController);
            ControlPanel = new ControlPanel.ControlPanel(autoController);

            DataContext = this;

            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}