using SmartHome.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.ControlPanel.Service
{
    public sealed class ControlService: IControlService
    {
        private readonly List<ISubscriber> subscribers = [];

        private IDevice? selectedDevice = null;

        private static ControlService? _instance = null;

        public static ControlService GetInstance()
        {
            _instance ??= new ControlService();
            return _instance;
        }

        public void AddSubscriber(ISubscriber subscriber) {
            subscribers.Add(subscriber);
        }

        public void RemoveSubscriber() { }

        public void SelectDevice(IDevice? device)
        {
            selectedDevice = device;

            subscribers.ForEach((subscriber) =>
            {
                subscriber.Update(selectedDevice);
            });

            Console.WriteLine(selectedDevice?.ToString());
        }
    }
}
