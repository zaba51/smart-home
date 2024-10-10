using SmartHome.DeviceGrid.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Devices
{
    public class Thermostat: DeviceBase, IDevice
    {
        public string Name { get; private set; }

        private int _temperature;
        public int Temperature {
            get
            {
                return _temperature;
            }
            set
            {
                _temperature = value;
                _mediator?.Notify(this);
            } 
        }

        //public event Action<void> OnValueChange;

        public Thermostat()
        {
            Name = "Thermostat";
            Temperature = 22;
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
