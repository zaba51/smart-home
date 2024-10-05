using System;
using System.Collections.Generic;
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

namespace SmartHome.DeviceGrid.Widget
{
    public partial class DeviceWidgetControl : UserControl
    {
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(DeviceWidget), typeof(DeviceWidgetControl),
                new PropertyMetadata(null));

        public DeviceWidget ViewModel
        {
            get { return (DeviceWidget)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
        public DeviceWidgetControl()
        {
            InitializeComponent();
            //DataContext = ViewModel;
        }

        private static void OnPropertySet(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DeviceWidgetControl ctrl) ctrl.ViewModel = (DeviceWidget)e.NewValue;
        }

        private void DeviceWidget_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.OnClick();
        }
    }
}
