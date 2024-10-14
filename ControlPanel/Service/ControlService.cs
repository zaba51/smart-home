using SmartHome.DeviceGrid.Widget;
using SmartHome.Devices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.ControlPanel.Service
{
    public sealed class ControlService: IControlService
    {
        public Dictionary<string, List<IDevice>> Rooms { get; private set; } = [];
        public IDevice? SelectedDevice { get; private set; }

        private readonly List<ISubscriber> subscribers = [];

        private static ControlService? _instance = null;

        public static ControlService GetInstance()
        {
            _instance ??= new ControlService();
            return _instance;
        }

        public void AddDevice(string roomName, IDevice device)
        {
            if (!Rooms.ContainsKey(roomName))
            {
                Rooms[roomName] = new List<IDevice>();
            }

            Rooms[roomName].Add(device);
            Next();
        }

        public void SelectDevice(IDevice? device)
        {
            SelectedDevice = device;
            Next();
        }
        public void AddSubscriber(ISubscriber subscriber)
        {
            subscribers.Add(subscriber);
        }

        private void Next()
        {
            subscribers.ForEach((subscriber) =>
            {
                subscriber.Update(this);
            });
        }
    }
}
