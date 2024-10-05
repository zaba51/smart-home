using SmartHome.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DeviceGrid
{
    class DeviceFactory
    {
        public LEDLight CreateLEDLight() {
            return new LEDLight();
        }

        public Thermostat CreateThermostat()
        {
            return new Thermostat();
        }
    }
}
