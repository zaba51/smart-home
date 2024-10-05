using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Devices
{
    class LEDLight: IDevice
    {
        public string Name { get; private set; }
        private int _brightness;
        private string _color;

        public LEDLight()
        {
            Name = "LEDLight";
            _brightness = 0;
            _color = "white";
        }
        

        public void SetBrightness(int level)
        {
            _brightness = level;
            Console.WriteLine($"{Name}: Setting brightness to {level}%");
        }

        public void SetColor(string color)
        {
            _color = color;
        }
        public string GetStatus()
        {
            return $"Brightness: {_brightness}\nColor: {_color}";
        }
    }
}
