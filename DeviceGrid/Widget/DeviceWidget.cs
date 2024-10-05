using SmartHome.DeviceGrid.Widget.State;
using SmartHome.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DeviceGrid.Widget
{
    public class DeviceWidget : IWidget, INotifyPropertyChanged
    {
        private readonly IDevice _device;
        private WidgetState _state;

        public event Action<DeviceWidget> OnClickEvent;
        public event PropertyChangedEventHandler? PropertyChanged;

        public string DeviceName => _device.Name;

        public bool IsSelected
        {
            get {
                return _state is SelectedState;
            }
        }

        #pragma warning disable CS8618
        public DeviceWidget(IDevice device) {
        #pragma warning restore CS8618
            _device = device;
            ChangeState(new DefaultState(this));
        }

        public void OnClick()
        {
            _state.OnClick();

            OnClickEvent?.Invoke(this);
            // now if state is Selected, send _device to DeviceGrid
            // now if state is Default, send null to Device Grid 
        }

        public void Deselect()
        {
            ChangeState(new DefaultState(this));
        }

        public void ChangeState(WidgetState state)
        {
            _state = state;
            OnPropertyChanged(nameof(IsSelected));
        }

        public IDevice GetComponent()
        {
            return _device;
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
