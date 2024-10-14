using SmartHome.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.ControlPanel.AutoController.Handlers
{
    public class ClockHandler : IDeviceHandler
    {
        private IDeviceHandler _nextHandler;

        public void SetNext(IDeviceHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public void Handle(IDevice device, List<IDevice> devices)
        {
            if (device is Clock clock)
            {
                foreach (var item in devices)
                {
                    if (item is Thermostat thermostat && thermostat.IsAutoMode)
                    {
                        if (clock.Time.Hour > 18)
                        {
                            thermostat.SetTemperature(23);
                        }
                        else if (clock.Time.Hour > 8)
                        {
                            thermostat.SetTemperature(21);
                        }
                    }
                }
            }
            else
            {
                _nextHandler?.Handle(device, devices);
            }

        }
    }
}
