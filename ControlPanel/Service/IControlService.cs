using SmartHome.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.ControlPanel.Service
{
    public interface IControlService
    {
        public void AddSubscriber() { }

        public void RemoveSubscriber() { }

        public void SelectDevice(IDevice? device);
    }
}
