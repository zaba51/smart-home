﻿using SmartHome.ControlPanel.Service;
using SmartHome.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.ControlPanel
{
    public class ControlPanel : ISubscriber, INotifyPropertyChanged
    {
        private readonly ControlService _controlService;

        public event PropertyChangedEventHandler? PropertyChanged;

        public IDevice? SelectedDevice { get; private set; }

        public string DeviceInfo => SelectedDevice?.GetStatus() ?? "";

        public ControlPanel() { 
            _controlService = ControlService.GetInstance();
            _controlService.AddSubscriber(this);
        }

        public void Update(IDevice? selectedDevice)
        {
            SelectedDevice = selectedDevice;
            OnPropertyChanged(nameof(SelectedDevice));
            OnPropertyChanged(nameof(DeviceInfo));
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
