using SmartHome.DeviceGrid.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Devices
{
    public class Thermostat: IDevice
    {
        public string Name { get; private set; }
        public int Temperature { get; set; }

        //public event Action<void> OnValueChange;

        public Thermostat()
        {
            Name = "Thermostat";
            Temperature = 0;
        }

        public void SetTemperature(int temp)
        {
            Temperature = temp;
            Console.WriteLine($"{Name}: Setting temperature to {temp}°C");
        }

        public string GetStatus()
        {
            return $"Temperature: {Temperature}C";
        }
    }
}
