using SmartHome.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.ControlPanel.AutoController.Handlers
{
    public class ThermostatHandler : IDeviceHandler
    {
        private IDeviceHandler _nextHandler;

        public void SetNext(IDeviceHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public void Handle(IDevice device, List<IDevice> devices)
        {
            if (device is Thermostat thermostat)
            {
                foreach (var item in devices)
                {
                    if (item is LEDLight lights && lights.IsAutoMode)
                    {
                        var t = thermostat.Temperature;
                        var red = (t * 30 - 460);
                        lights.R = Math.Clamp(red, 0, 255);
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
