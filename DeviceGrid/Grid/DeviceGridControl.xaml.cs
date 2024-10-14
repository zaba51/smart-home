using SmartHome.ControlPanel.Service;
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

namespace SmartHome.DeviceGrid.Grid
{
    public partial class DeviceGridControl : UserControl
    {
        private DeviceGrid _deviceGrid;

        //public ObservableCollection<IWidget> Widgets => _deviceGrid.Widgets;
        public ObservableCollection<Room> Rooms => _deviceGrid.Rooms;

        public DeviceGridControl()
        {
            InitializeComponent();
            SetupDeviceGrid();
        }

        private void SetupDeviceGrid()
        {
            var controlService = ControlService.GetInstance();
            _deviceGrid = new DeviceGrid(controlService);
            //DeviceWidgetsList.ItemsSource = _deviceGrid.Widgets;
            DataContext = _deviceGrid;
        }
    }
}
