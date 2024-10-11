using SmartHome.Devices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.ControlPanel.AutoController
{
    public class AutoController : IMediator
    {
        private readonly List<IDevice> _devices = [];

        public void AddItem(object device)
        {
            _devices.Add((IDevice)device);
        }

        public void Notify(object sender)
        {
            IDevice device = (IDevice)sender;

            if (device is Thermostat thermostat)
            {
                HandleThermostat(thermostat);
            }
            else if (device is Clock clock)
            {
                HandleClock(clock);
            }
        }

        private void HandleThermostat(Thermostat thermostat)
        {
            foreach (var item in _devices)
            {
                if (item is LEDLight lights && lights.IsAutoMode)
                {
                    //lights.Brightness = thermostat.Temperature > 21 ? 90: 40;
                    var t = thermostat.Temperature;
                    //lights.Color = Color.FromArgb(255, t*30-460, 1, 1);
                    var red = (t * 30 - 460);
                    lights.R = Math.Clamp(red, 0, 255);
                }
            }
        }

        private void HandleClock(Clock clock)
        {
            return;
            foreach(var item in _devices)
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
    }
}
