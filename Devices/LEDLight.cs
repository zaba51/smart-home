using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Devices
{
    class LEDLight: DeviceBase, IDevice, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public string Name { get; private set; }

        private int _brightness;
        public int Brightness {
            get {
                return _brightness;
            }
            set {
                _brightness = value;
                _mediator?.Notify(this);
                OnPropertyChanged(nameof(Brightness));
            }
        }

        public Color Color;

        public System.Windows.Media.Color TemplateColor
            => System.Windows.Media.Color.FromArgb(255, Color.R, Color.G, Color.B);

        private int _r = 0;
        private int _g = 0;
        private int _b = 0;
        public int R
        {
            get { return _r; }
            set { _r = value; CorrectColor(); OnPropertyChanged(nameof(R)); }
        }
        public int G
        {
            get { return _g; }
            set { _g = value; CorrectColor(); OnPropertyChanged(nameof(G)); }
        }
        public int B
        {
            get { return _b; }
            set { _b = value; CorrectColor(); OnPropertyChanged(nameof(B)); }
        }

        private void CorrectColor()
        {
            Color = System.Drawing.Color.FromArgb(_brightness, _r, _g, _b);
            _mediator?.Notify(this);
            OnPropertyChanged(nameof(Color));
            OnPropertyChanged(nameof(TemplateColor));
        }

        public LEDLight()
        {
            Name = "LEDLight";
            Brightness = 100;
            Color = Color.FromArgb(255, 255, 255, 255);
        }
        
        public void SetBrightness(int level)
        {
            Brightness = level;
            Console.WriteLine($"{Name}: Setting brightness to {level}%");
        }

        public string GetStatus()
        {
            return $"Brightness: {Brightness}\nColor: {Color}";
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
