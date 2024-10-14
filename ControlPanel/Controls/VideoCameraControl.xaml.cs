using SmartHome.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartHome.ControlPanel.Controls
{
    /// <summary>
    /// Interaction logic for VideoCameraControl.xaml
    /// </summary>
    public partial class VideoCameraControl : UserControl
    {
        private Camera _camera;

        public VideoCameraControl()
        {
            InitializeComponent();
            this.Loaded += VideoCameraControl_Loaded;

        }

        private void VideoCameraControl_Loaded(object sender, RoutedEventArgs e)
        {
            _camera = DataContext as Camera;
        }

        private void OnToggleRecordingClick(object sender, RoutedEventArgs e)
        {
            _camera.IsRecording = !_camera.IsRecording;

            ToggleRecordingButton.Content = _camera.IsRecording ? "Stop Recording" : "Start Recording";

            //// Start or stop the timer
            //if (_camera.IsRecording)
            //{
            //    _recordingTimer.Start();
            //}
            //else
            //{
            //    _recordingTimer.Stop();
            //}
        }

        private void OnOpenFolderClick(object sender, RoutedEventArgs e)
        {
            _camera.OpenFolder();
        }
    }
}
