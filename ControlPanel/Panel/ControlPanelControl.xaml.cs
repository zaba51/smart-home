using SmartHome.ControlPanel.Service;
using SmartHome.DeviceGrid;
using SmartHome.DeviceGrid.Grid;
using SmartHome.DeviceGrid.Widget;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartHome.ControlPanel.Panel
{
    /// <summary>
    /// Interaction logic for ControlPanelControl.xaml
    /// </summary>
    public partial class ControlPanelControl : UserControl
    {
        private ControlPanel _controlPanel;

        public ControlPanelControl()
        {
            InitializeComponent();

            this.Loaded += DevicePanelControl_Loaded;
        }

        private void DevicePanelControl_Loaded(object sender, RoutedEventArgs e)
        {
            _controlPanel = DataContext as ControlPanel;
        }
    }
}
