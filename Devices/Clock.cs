using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SmartHome.Devices
{
    public class Clock: DeviceBase, IDevice, INotifyPropertyChanged
    {
        public DateTime Time {
            get {
                return _time;
            }
            set {
                _time = value;
                _mediator?.Notify(this);
                OnPropertyChanged(nameof(Time));
                OnPropertyChanged(nameof(DateText));
            }
        }

        public string DateText => Time.ToString();

        public string Name => "Clock";

        private DateTime _time;

        private DispatcherTimer _timer;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Clock()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Tickevent;
            _timer.Start();
        }

        ~Clock()
        {
            _timer.Stop();
        }

        private void Tickevent(object? sender, EventArgs e)
        {
            Time = DateTime.Now;
        }

        public string GetStatus()
        {
            throw new NotImplementedException();
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
