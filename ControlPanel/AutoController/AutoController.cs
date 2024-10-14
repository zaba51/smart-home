using SmartHome.DeviceGrid.Widget;
using SmartHome.Devices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHome.ControlPanel.AutoController.Handlers;

namespace SmartHome.ControlPanel.AutoController
{
    public class AutoController : IMediator
    {
        private readonly List<IDevice> _devices = [];
        private readonly IDeviceHandler _deviceHandlerChain;

        public AutoController()
        {
            var thermostatHandler = new ThermostatHandler();
            var clockHandler = new ClockHandler();
            thermostatHandler.SetNext(clockHandler);
            _deviceHandlerChain = thermostatHandler;
        }

        public void AddItem(object device)
        {
            _devices.Add((IDevice)device);
        }

        public void Notify(object sender)
        {
            var currentDevice = (IDevice)sender;

            _deviceHandlerChain.Handle(currentDevice, _devices);
        }
    }
}
