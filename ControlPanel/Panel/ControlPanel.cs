using SmartHome.ControlPanel.Service;
using SmartHome.DeviceGrid;
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
        private readonly IControlService _controlService;

        public event PropertyChangedEventHandler? PropertyChanged;

        public IDevice? SelectedDevice { get; private set; } = null;

        public Clock Clock { get; private set; }
         
        public string DeviceInfo => "" ?? SelectedDevice?.GetStatus();

        public ControlPanel(AutoController.AutoController autoController) { 
            _controlService = ControlService.GetInstance();
            _controlService.AddSubscriber(this);

            var deviceFactory = new DeviceFactory(autoController);
            Clock = deviceFactory.CreateClock();
        }

        public void Update(IControlService service)
        {
            SelectedDevice = service.SelectedDevice;
            OnPropertyChanged(nameof(SelectedDevice));
            OnPropertyChanged(nameof(DeviceInfo));
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
