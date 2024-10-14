using SmartHome.ControlPanel.AutoController;
using SmartHome.ControlPanel.Service;
using SmartHome.DeviceGrid;
using SmartHome.Devices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace SmartHome.ControlPanel.DevicePanel
{
    public class DevicePanel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _currentRoom;
        public string CurrentRoom
        {
            get => _currentRoom;
            set
            {
                _currentRoom = value;
                OnPropertyChanged();
            }
        }

        public List<string> Devices { get; } = new List<string> { "Thermostat", "LEDLight", "VideoCamera" };
        public string CurrentDevice { get; set; } = "";

        private readonly IControlService _controlService;
        private readonly DeviceFactory _deviceFactory;

        public DevicePanel(AutoController.AutoController autoController)
        {
            _deviceFactory = new DeviceFactory(autoController);
            _controlService = ControlService.GetInstance();
        }

        public void AddDevice(string deviceName)
        {
            IDevice device = _deviceFactory.CreateDevice(deviceName);

            if (!string.IsNullOrEmpty(CurrentRoom) && device != null) {
                _controlService.AddDevice(CurrentRoom, device);
            }
            else
            {
                MessageBox.Show("Please select a device and room.");
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
